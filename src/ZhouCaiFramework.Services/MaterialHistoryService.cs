using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class MaterialHistoryService : IMaterialHistoryService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<MaterialHistoryService> _logger;

        public MaterialHistoryService(ISqlSugarClient db, ILogger<MaterialHistoryService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<PaginatedList<MaterialHistoryDto>> GetMaterialHistoriesAsync(MaterialHistoryQueryDto query)
        {
            try
            {
                var q = _db.Queryable<MaterialHistory>()
                    .LeftJoin<Material>((mh, m) => mh.MaterialId == m.Id)
                    .LeftJoin<Employee>((mh, m, e) => mh.OperatorId == e.Id)
                    .LeftJoin<Project>((mh, m, e, p) => mh.ProjectId == p.Id)
                    .LeftJoin<Warehouse>((mh, m, e, p, w) => mh.WarehouseId == w.Id);

                // 材料ID筛选
                if (query.MaterialId > 0)
                {
                    q = q.Where(mh => mh.MaterialId == query.MaterialId);
                }

                // 材料编码筛选
                if (!string.IsNullOrEmpty(query.MaterialCode))
                {
                    q = q.Where(mh => mh.MaterialCode.Contains(query.MaterialCode));
                }

                // 事件类型筛选
                if (!string.IsNullOrEmpty(query.EventType))
                {
                    q = q.Where(mh => mh.EventType == query.EventType);
                }

                // 时间范围筛选
                if (query.StartTime.HasValue)
                {
                    q = q.Where(mh => mh.EventTime >= query.StartTime);
                }
                if (query.EndTime.HasValue)
                {
                    q = q.Where(mh => mh.EventTime <= query.EndTime);
                }

                // 仓库筛选
                if (query.WarehouseId.HasValue)
                {
                    q = q.Where(mh => mh.WarehouseId == query.WarehouseId);
                }

                // 项目筛选
                if (query.ProjectId.HasValue)
                {
                    q = q.Where(mh => mh.ProjectId == query.ProjectId);
                }

                // 操作人筛选
                if (!string.IsNullOrEmpty(query.OperatorName))
                {
                    q = q.Where((mh, m, e) => e.Name.Contains(query.OperatorName));
                }

                // 获取总数
                var total = await q.CountAsync();

                // 分页查询并映射到Dto
                var materialHistories = await q.Select(mh => new MaterialHistoryDto
                {
                    Id = mh.Id,
                    MaterialId = mh.MaterialId,
                    MaterialName = mh.Material.Name, // 假设 Material 类有 Name 属性
                    MaterialCode = mh.MaterialCode,
                    EventTime = mh.EventTime,
                    EventType = mh.EventType,
                    DocumentNo = mh.DocumentNo,
                    Description = mh.Description,
                    Location = mh.Location,
                    QuantityChange = mh.QuantityChange,
                    WeightChange = mh.WeightChange,
                    OperatorName = mh.Operator.Name, // 假设 Employee 类有 Name 属性
                    OperatorPhone = mh.Operator.Phone, // 假设 Employee 类有 Phone 属性
                    StatusBefore = mh.StatusBefore,
                    StatusAfter = mh.StatusAfter,
                    ProjectName = mh.Project.Name, // 假设 Project 类有 Name 属性
                    WarehouseName = mh.Warehouse.Name // 假设 Warehouse 类有 Name 属性
                }).ToPageListAsync(query.PageIndex, query.PageSize);

                return new PaginatedList<MaterialHistoryDto>(materialHistories, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取材料历史记录失败 MaterialId:{MaterialId}", query.MaterialId);
                throw; // 保持抛出异常以允许上游处理
            }
        }
    }
}