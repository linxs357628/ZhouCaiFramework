using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class MaterialLockService : IMaterialLockService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<MaterialLockService> _logger;

        public MaterialLockService(ISqlSugarClient db, ILogger<MaterialLockService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<PaginatedList<MaterialLockDto>> GetMaterialLocksAsync(MaterialLockQueryDto query)
        {
            try
            {
                var q = _db.Queryable<MaterialLock>()
                    .LeftJoin<Material>((ml, m) => ml.MaterialId == m.Id)
                    .LeftJoin<Project>((ml, m, p) => ml.ProjectId == p.Id)
                    .LeftJoin<Warehouse>((ml, m, p, w) => ml.WarehouseId == w.Id)
                    .LeftJoin<Employee>((ml, m, p, w, e) => ml.OperatorId == e.Id);

                // 关键词搜索
                if (!string.IsNullOrEmpty(query.Keyword))
                {
                    q = q.Where((ml, m, p, w, e) => 
                        ml.DocumentNo.Contains(query.Keyword) ||
                        p.Name.Contains(query.Keyword) ||
                        m.Name.Contains(query.Keyword) ||
                        e.Name.Contains(query.Keyword));
                }

                // 材料分类筛选
                if (query.MaterialCategoryId.HasValue)
                {
                    q = q.Where((ml, m) => m.CategoryId == query.MaterialCategoryId);
                }

                if (query.MaterialSubCategoryId.HasValue)
                {
                    q = q.Where((ml, m) => m.SubCategoryId == query.MaterialSubCategoryId);
                }

                if (query.MaterialId.HasValue)
                {
                    q = q.Where((ml, m) => m.Id == query.MaterialId);
                }

                // 提交时间筛选
                if (query.SubmitStartTime.HasValue)
                {
                    q = q.Where(ml => ml.CreateTime >= query.SubmitStartTime);
                }

                if (query.SubmitEndTime.HasValue)
                {
                    q = q.Where(ml => ml.CreateTime <= query.SubmitEndTime);
                }

                // 计划时间筛选
                if (query.PlanStartTime.HasValue)
                {
                    q = q.Where(ml => ml.PlanTime >= query.PlanStartTime);
                }

                if (query.PlanEndTime.HasValue)
                {
                    q = q.Where(ml => ml.PlanTime <= query.PlanEndTime);
                }

                // 出入库类型筛选
                if (!string.IsNullOrEmpty(query.Type))
                {
                    q = q.Where(ml => ml.Type == query.Type);
                }

                // 锁库状态筛选
                if (query.IsLocked.HasValue)
                {
                    var now = DateTime.Now;
                    if (query.IsLocked.Value)
                    {
                        q = q.Where(ml => ml.PlanTime > now);
                    }
                    else
                    {
                        q = q.Where(ml => ml.PlanTime <= now);
                    }
                }

                // 默认按创建时间降序
                q = q.OrderBy(ml => ml.CreateTime, OrderByType.Desc);

                // 分页查询
                var total = await q.CountAsync();
                var items = await q.Select((ml, m, p, w, e) => new MaterialLockDto
                {
                    Id = ml.Id,
                    DocumentNo = ml.DocumentNo,
                    ProjectName = p.Name,
                    Type = ml.Type,
                    Reason = ml.Reason,
                    LockDays = ml.LockDays,
                    Weight = ml.Weight,
                    Quantity = ml.Quantity,
                    CreateTime = ml.CreateTime,
                    PlanTime = ml.PlanTime,
                    Renter = ml.Renter,
                    WarehouseName = w.Name,
                    Status = ml.Status,
                    OperatorName = e.Name,
                    OperatorPhone = e.Phone,
                    IsScanned = ml.IsScanned,
                    MaterialName = m.Name,
                    MaterialCode = m.Code
                }).ToPageListAsync(query.PageIndex, query.PageSize);

                return new PaginatedList<MaterialLockDto>(items, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取锁库记录列表失败");
                throw;
            }
        }

        public async Task<List<MaterialDetailDto>> GetMaterialDetailsAsync(int lockId)
        {
            try
            {
                return await _db.Queryable<MaterialDetail>()
                    .Where(md => md.LockId == lockId)
                    .Select<MaterialDetailDto>()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取材料明细失败 LockId:{LockId}", lockId);
                throw;
            }
        }

        public async Task<bool> ToggleLockStatusAsync(int lockId)
        {
            try
            {
                var lockRecord = await _db.Queryable<MaterialLock>()
                    .Where(ml => ml.Id == lockId)
                    .FirstAsync();

                if (lockRecord == null)
                    return false;

                // 切换锁库状态
                var newStatus = lockRecord.PlanTime > DateTime.Now ? 
                    "已解锁" : "已锁定";

                return await _db.Updateable<MaterialLock>()
                    .SetColumns(ml => ml.Status == newStatus)
                    .Where(ml => ml.Id == lockId)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "切换锁库状态失败 LockId:{LockId}", lockId);
                throw;
            }
        }
    }
}
