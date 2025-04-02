using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialDetailService
    {
        Task<PaginatedList<MaterialDetail>> GetDetails(
            int materialId,
            string keyword,
            List<string> categories,
            DateTime? startDate,
            DateTime? endDate,
            List<string> statuses,
            int? minDays,
            int? maxDays,
            int page,
            int pageSize);

        Task<List<MaterialHistory>> GetMaterialHistory(string materialCode);
    }
}