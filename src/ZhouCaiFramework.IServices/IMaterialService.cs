using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialService
    {
        Task<PaginatedList<MaterialResponseDto>> GetMaterialsAsync(MaterialQueryDto query);

        Task<MaterialResponseDto> GetMaterialDetailAsync(int id);

        Task<MaterialStatsDto> GetMaterialStatsAsync(MaterialQueryDto query);

        Task<byte[]> ExportMaterialsAsync(MaterialQueryDto query);

        Task<List<string>> GetActiveCategoriesAsync();

        Task<List<string>> GetActiveSubCategoriesAsync(string category);

        Task<List<MaterialHistoryDto>> GetMaterialHistoryAsync(int materialId);

        // 图片管理
        Task<List<MaterialImageDto>> GetMaterialImagesAsync(int materialId);

        Task<MaterialImageDto> UploadMaterialImageAsync(UploadImageDto dto, Stream fileStream, string fileName);

        Task<bool> DeleteMaterialImageAsync(int imageId);

        Task<MaterialImageDto> UpdateMaterialImageAsync(int imageId, UpdateImageDto dto);
    }
}