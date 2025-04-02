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
    public class MaterialCategoryService : IMaterialCategoryService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<MaterialCategoryService> _logger;

        public MaterialCategoryService(ISqlSugarClient db, ILogger<MaterialCategoryService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<PaginatedList<MaterialCategoryDto>> GetCategoriesAsync(MaterialCategoryQueryDto query)
        {
            try
            {
                var q = _db.Queryable<MaterialCategory>();

                // 关键词搜索
                if (!string.IsNullOrEmpty(query.Keyword))
                {
                    q = q.Where(c => c.Name.Contains(query.Keyword));
                }

                // 上级类目筛选
                if (query.ParentId.HasValue)
                {
                    q = q.Where(c => c.ParentId == query.ParentId);
                }

                // 可见性筛选
                if (query.IsVisible.HasValue)
                {
                    q = q.Where(c => c.IsVisible == query.IsVisible);
                }

                // 默认按排序值降序
                q = q.OrderBy(c => c.SortOrder, OrderByType.Desc)
                    .OrderBy(c => c.Id, OrderByType.Desc);

                // 分页查询
                var total = await q.CountAsync();
                var items = await q.Select<MaterialCategoryDto>()
                    .ToPageListAsync(query.PageIndex, query.PageSize);

                return new PaginatedList<MaterialCategoryDto>(items, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取周转材料类目列表失败");
                throw;
            }
        }

        public async Task<MaterialCategoryDto> GetCategoryAsync(int id)
        {
            try
            {
                var category = await _db.Queryable<MaterialCategory>()
                    .Where(c => c.Id == id)
                    .Select<MaterialCategoryDto>()
                    .FirstAsync();

                if (category.ParentId.HasValue)
                {
                    var parent = await _db.Queryable<MaterialCategory>()
                        .Where(c => c.Id == category.ParentId)
                        .FirstAsync();
                    category.ParentName = parent?.Name;
                }

                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取周转材料类目详情失败 ID:{Id}", id);
                throw;
            }
        }

        public async Task<int> CreateCategoryAsync(MaterialCategoryDto dto)
        {
            try
            {
                var category = new MaterialCategory
                {
                    Name = dto.Name,
                    ParentId = dto.ParentId,
                    IsVisible = dto.IsVisible,
                    SortOrder = await GetNextSortOrderAsync()
                };

                return await _db.Insertable(category).ExecuteReturnIdentityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建周转材料类目失败");
                throw;
            }
        }

        public async Task<bool> UpdateCategoryAsync(MaterialCategoryDto dto)
        {
            try
            {
                return await _db.Updateable<MaterialCategory>()
                    .SetColumns(c => new MaterialCategory
                    {
                        Name = dto.Name,
                        ParentId = dto.ParentId,
                        IsVisible = dto.IsVisible,
                        SortOrder = dto.SortOrder
                    })
                    .Where(c => c.Id == dto.Id)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新周转材料类目失败 ID:{Id}", dto.Id);
                throw;
            }
        }

        public async Task<bool> ToggleVisibilityAsync(int id)
        {
            try
            {
                return await _db.Updateable<MaterialCategory>()
                    .SetColumns(c => c.IsVisible == !c.IsVisible)
                    .Where(c => c.Id == id)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "切换周转材料类目显示状态失败 ID:{Id}", id);
                throw;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                return await _db.Deleteable<MaterialCategory>()
                    .Where(c => c.Id == id)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除周转材料类目失败 ID:{Id}", id);
                throw;
            }
        }

        public async Task<List<MaterialCategoryDto>> GetParentCategoriesAsync()
        {
            try
            {
                return await _db.Queryable<MaterialCategory>()
                    .Where(c => c.ParentId == null)
                    .Select<MaterialCategoryDto>()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取父级类目列表失败");
                throw;
            }
        }

        private async Task<int> GetNextSortOrderAsync()
        {
            var maxOrder = await _db.Queryable<MaterialCategory>()
                .MaxAsync(c => (int?)c.SortOrder) ?? 0;
            return maxOrder + 1;
        }
    }
}
