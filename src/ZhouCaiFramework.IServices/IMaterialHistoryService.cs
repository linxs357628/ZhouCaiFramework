using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialHistoryService
    {
        Task<PaginatedList<MaterialHistoryDto>> GetMaterialHistoriesAsync(MaterialHistoryQueryDto query);
    }
}
