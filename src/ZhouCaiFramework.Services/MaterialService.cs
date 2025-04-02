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
    public class MaterialService : IMaterialService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<MaterialService> _logger;
        private readonly IFileStorageService _fileStorage;
        private readonly IOperationLogService _logService;

        public MaterialService(
            ISqlSugarClient db,
            ILogger<MaterialService> logger,
            IFileStorageService fileStorage,
            IOperationLogService logService)
        {
            _db = db;
            _logger = logger;
            _fileStorage = fileStorage;
            _logService = logService;
        }

        public async Task<PaginatedList<MaterialResponseDto>> GetMaterialsAsync(MaterialQueryDto query)
        {
            try
            {
                var q = _db.Queryable<Material>();

                // 关键字搜索
                if (!string.IsNullOrEmpty(query.Keyword))
                {
                    q = q.Where(m => m.Code.Contains(query.Keyword) ||
                                   m.Name.Contains(query.Keyword) ||
                                   m.Specification.Contains(query.Keyword) ||
                                   m.Location.Contains(query.Keyword));
                }

                // 类目筛选
                if (!string.IsNullOrEmpty(query.Category))
                {
                    q = q.Where(m => m.Category == query.Category);
                }

                // 品名筛选
                if (!string.IsNullOrEmpty(query.Name))
                {
                    q = q.Where(m => m.Name == query.Name);
                }

                // 规格筛选
                if (!string.IsNullOrEmpty(query.Specification))
                {
                    q = q.Where(m => m.Specification == query.Specification);
                }

                // 挂单状态筛选
                if (query.IsListed.HasValue)
                {
                    q = q.Where(m => m.IsListed == query.IsListed);
                }

                // 材料状态筛选
                if (!string.IsNullOrEmpty(query.Status))
                {
                    q = q.Where(m => m.Status == query.Status);
                }

                // 初次上报时间范围筛选
                if (query.FirstReportStart.HasValue)
                {
                    q = q.Where(m => m.FirstReportTime >= query.FirstReportStart);
                }
                if (query.FirstReportEnd.HasValue)
                {
                    q = q.Where(m => m.FirstReportTime <= query.FirstReportEnd);
                }

                // 最近上报时间范围筛选
                if (query.LastReportStart.HasValue)
                {
                    q = q.Where(m => m.LastReportTime >= query.LastReportStart);
                }
                if (query.LastReportEnd.HasValue)
                {
                    q = q.Where(m => m.LastReportTime <= query.LastReportEnd);
                }

                // 位置周期筛选
                if (query.MinLocationCycle.HasValue)
                {
                    q = q.Where(m => m.LocationCycle >= query.MinLocationCycle);
                }
                if (query.MaxLocationCycle.HasValue)
                {
                    q = q.Where(m => m.LocationCycle <= query.MaxLocationCycle);
                }

                // 获取总数
                var total = await q.CountAsync();

                // 分页查询
                var items = await q.OrderBy(m => m.LastReportTime, OrderByType.Desc)
                    .Select<MaterialResponseDto>()
                    .ToPageListAsync(query.PageIndex, query.PageSize);

                return new PaginatedList<MaterialResponseDto>(items, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取周转材料列表失败");
                throw;
            }
        }

        public async Task<MaterialResponseDto> GetMaterialDetailAsync(int id)
        {
            try
            {
                return await _db.Queryable<Material>()
                    .Where(m => m.Id == id)
                    .Select<MaterialResponseDto>()
                    .FirstAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取周转材料详情失败 ID:{Id}", id);
                throw;
            }
        }

        public async Task<MaterialStatsDto> GetMaterialStatsAsync(MaterialQueryDto query)
        {
            try
            {
                var q = ApplyQueryConditions(_db.Queryable<Material>(), query);

                return new MaterialStatsDto
                {
                    TotalCount = await q.CountAsync(),
                    TotalQuantity = await q.SumAsync(m => m.Quantity),
                    TotalWeight = await q.SumAsync(m => m.Weight),
                    ActiveMaterials = await q.Where(m => m.Status == "良品").CountAsync(),
                    ScrappedMaterials = await q.Where(m => m.Status == "报废").CountAsync()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取周转材料统计信息失败");
                throw;
            }
        }

        public async Task<byte[]> ExportMaterialsAsync(MaterialQueryDto query)
        {
            try
            {
                var materials = await GetMaterialsAsync(query);
                // TODO: 使用NPOI或EPPlus实现Excel导出
                return Array.Empty<byte>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "导出周转材料数据失败");
                throw;
            }
        }

        private ISugarQueryable<Material> ApplyQueryConditions(ISugarQueryable<Material> query, MaterialQueryDto condition)
        {
            // 应用相同的查询条件...
            return query;
        }

        public async Task<bool> DeleteMaterialImageAsync(int imageId)
        {
            try
            {
                var image = await _db.Queryable<MaterialImage>()
                    .Where(x => x.Id == imageId)
                    .FirstAsync();

                if (image == null)
                {
                    return false;
                }

                // 开启事务
                var result = await _db.Ado.UseTranAsync(async () =>
                {
                    // 删除文件
                    await _fileStorage.DeleteFileAsync(image.ImageUrl);

                    // 删除记录
                    await _db.Deleteable<MaterialImage>()
                        .Where(x => x.Id == imageId)
                        .ExecuteCommandAsync();
                });

                return result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除材料图片失败 ID:{ImageId}", imageId);
                throw;
            }
        }

        public async Task<List<string>> GetActiveCategoriesAsync()
        {
            try
            {
                return await _db.Queryable<Material>()
                    .GroupBy(m => m.Category)
                    .Having(m => SqlFunc.AggregateCount(m.Id) > 0)
                    .Select(m => m.Category)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取活跃材料分类失败");
                throw;
            }
        }

        public async Task<List<MaterialImageDto>> GetMaterialImagesAsync(int materialId)
        {
            try
            {
                return await _db.Queryable<MaterialImage>()
                    .Where(x => x.MaterialId == materialId)
                    .Select<MaterialImageDto>()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取材料图片列表失败MaterialId:{MaterialId}", materialId);
                throw;
            }
        }

        public async Task<MaterialImageDto> UploadMaterialImageAsync(UploadImageDto dto, Stream fileStream, string fileName)
        {
            try
            {
                var uploadResult = await _fileStorage.SaveFileAsync(fileStream, fileName);

                var image = new MaterialImage
                {
                    MaterialId = dto.MaterialId,
                    ImageUrl = uploadResult,
                    Description = dto.Description,
                    UploadTime = DateTime.Now,
                    IsPrimary = dto.IsPrimary
                };

                await _db.Insertable(image).ExecuteCommandAsync();

                if (dto.IsPrimary)
                {
                    await _db.Updateable<Material>()
                        .SetColumns(m => m.MainImage == uploadResult)
                        .Where(m => m.Id == dto.MaterialId)
                        .ExecuteCommandAsync();
                }

                var result = await _db.Queryable<MaterialImage>()
                    .Where(x => x.ImageUrl == uploadResult)
                    .Select<MaterialImageDto>()
                    .FirstAsync();

                await _logService.RecordLogAsync("Material", "UploadImage",
                    $"上传材料图片:{result.Id}",
                    dto.OperatorId, dto.OperatorName, dto.IpAddress);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "上传材料图片失败");
                throw;
            }
        }

        public async Task<MaterialImageDto> UpdateMaterialImageAsync(int imageId, UpdateImageDto dto)
        {
            try
            {
                var image = await _db.Queryable<MaterialImage>()
                    .FirstAsync(x => x.Id == imageId);

                if (image == null)
                    throw new ArgumentException($"图片记录不存在:{imageId}");

                image.Description = dto.Description;
                image.IsPrimary = dto.IsPrimary;

                await _db.Updateable(image)
                    .ExecuteCommandAsync();

                if (dto.IsPrimary)
                {
                    await _db.Updateable<Material>()
                        .SetColumns(m => m.MainImage == image.ImageUrl)
                        .Where(m => m.Id == image.MaterialId)
                        .ExecuteCommandAsync();
                }

                var result = await _db.Queryable<MaterialImage>()
                    .Where(x => x.Id == imageId)
                    .Select<MaterialImageDto>()
                    .FirstAsync();

                await _logService.RecordLogAsync("Material", "UpdateImage",
                    $"更新材料图片:{imageId}",
                    dto.OperatorId, dto.OperatorName, dto.IpAddress);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新材料图片失败ImageId:{ImageId}", imageId);
                throw;
            }
        }

        public async Task<List<string>> GetActiveSubCategoriesAsync(string category)
        {
            try
            {
                return await _db.Queryable<SubCategory>()
                    .Where(sc => sc.Name == category && sc.IsActive)
                    .GroupBy(sc => sc.Name)
                    .Having(sc => SqlFunc.AggregateCount(sc.Id) > 0)
                    .Select(sc => sc.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取活跃子分类失败 Category:{Category}", category);
                throw;
            }
        }

        public async Task<List<MaterialHistoryDto>> GetMaterialHistoryAsync(int materialId)
        {
            try
            {
                return await _db.Queryable<MaterialHistory>()
                    .Where(mh => mh.MaterialId == materialId)
                    .OrderBy(mh => mh.EventTime, OrderByType.Desc)
                    .Select<MaterialHistoryDto>()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取材料历史记录失败 MaterialId:{MaterialId}", materialId);
                throw;
            }
        }
    }
}