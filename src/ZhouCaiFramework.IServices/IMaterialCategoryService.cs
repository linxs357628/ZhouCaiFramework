using System.Collections.Generic;
using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialCategoryService
    {
        Task<PaginatedList<MaterialCategoryDto>> GetCategoriesAsync(MaterialCategoryQueryDto query);
        Task<MaterialCategoryDto> GetCategoryAsync(int id);
        Task<int> CreateCategoryAsync(MaterialCategoryDto dto);
        Task<bool> UpdateCategoryAsync(MaterialCategoryDto dto);
        Task<bool> ToggleVisibilityAsync(int id);
        Task<bool> DeleteCategoryAsync(int id);
        Task<List<MaterialCategoryDto>> GetParentCategoriesAsync();
    }
}
