using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class MaterialOutboundService : IMaterialOutboundService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<MaterialOutboundService> _logger;

        public MaterialOutboundService(ISqlSugarClient db, ILogger<MaterialOutboundService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<MaterialDetailDto>> GetMaterialDetailsAsync(int outboundId)
        {
            try
            {
                return await _db.Queryable<MaterialDetail>()
                    .LeftJoin<Material>((md, m) => md.MaterialId == m.Id)
                    .LeftJoin<MaterialCategory>((md, m, mc) => m.CategoryId == mc.Id)
                    .Where(md => md.LockId == outboundId)
                    .Select((md, m, mc) => new MaterialDetailDto
                    {
                        Id = md.Id,
                        MaterialId = md.MaterialId,
                        MaterialName = m.Name,
                        CategoryName = mc.Name,
                        Specification = m.Specification,
                        Quantity = md.Quantity,
                        PackageCount = md.PackageCount,
                        Weight = md.Weight,
                        Owner = md.Owner,
                        Remark = md.Remark
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取材料明细失败 OutboundId:{OutboundId}", outboundId);
                throw;
            }
        }

        public async Task<int> CreateMaterialDetailAsync(MaterialDetailEditDto dto)
        {
            try
            {
                var detail = new MaterialDetail
                {
                    MaterialId = dto.MaterialId,
                    LockId = dto.LockId,
                    Quantity = dto.Quantity,
                    PackageCount = dto.PackageCount,
                    Weight = dto.Weight,
                    Owner = dto.Owner,
                    Remark = dto.Remark
                };
                return await _db.Insertable(detail).ExecuteReturnIdentityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建材料明细失败");
                throw;
            }
        }

        public async Task<bool> UpdateMaterialDetailAsync(MaterialDetailEditDto dto)
        {
            try
            {
                return await _db.Updateable<MaterialDetail>()
                    .SetColumns(md => new MaterialDetail
                    {
                        MaterialId = dto.MaterialId,
                        Quantity = dto.Quantity,
                        PackageCount = dto.PackageCount,
                        Weight = dto.Weight,
                        Owner = dto.Owner,
                        Remark = dto.Remark
                    })
                    .Where(md => md.Id == dto.Id)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新材料明细失败 DetailId:{DetailId}", dto.Id);
                throw;
            }
        }

        public async Task<bool> DeleteMaterialDetailAsync(int detailId)
        {
            try
            {
                return await _db.Deleteable<MaterialDetail>()
                    .Where(md => md.Id == detailId)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除材料明细失败 DetailId:{DetailId}", detailId);
                throw;
            }
        }

        public async Task<MaterialOutboundDetailDto> GetOutboundDetailAsync(int outboundId)
        {
            try
            {
                var detail = await _db.Queryable<MaterialLock>()
                    .LeftJoin<Warehouse>((ml, w) => ml.WarehouseId == w.Id)
                    .LeftJoin<Employee>((ml, w, e) => ml.OperatorId == e.Id)
                    .Where(ml => ml.Id == outboundId)
                    .Select((ml, w, e) => new MaterialOutboundDetailDto
                    {
                        CreateTime = ml.CreateTime,
                        DocumentNo = ml.DocumentNo,
                        PlanOutboundTime = ml.PlanTime,
                        WarehouseName = w.Name,
                        Location = ml.Location,
                        Reason = ml.Reason,
                        TotalWeight = ml.Weight,
                        Owner = ml.Renter,
                        KeeperName = e.Name,
                        KeeperPhone = e.Phone,
                        ShippingPlace = w.Address,
                        ReceivingPlace = ml.ProjectName
                    }).FirstAsync();

                if (detail != null)
                {
                    detail.Items = await _db.Queryable<MaterialDetail>()
                        .LeftJoin<Material>((md, m) => md.MaterialId == m.Id)
                        .LeftJoin<MaterialCategory>((md, m, mc) => m.CategoryId == mc.Id)
                        .Where(md => md.LockId == outboundId)
                        .Select((md, m, mc) => new MaterialOutboundItemDto
                        {
                            CategoryName = mc.Name,
                            MaterialName = m.Name,
                            Specification = m.Specification,
                            Quantity = md.Quantity,
                            PackageCount = md.PackageCount,
                            Weight = md.Weight,
                            Owner = md.Owner
                        }).ToListAsync();
                }

                return detail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取出库单详情失败 OutboundId:{OutboundId}", outboundId);
                throw;
            }
        }
    }
}
