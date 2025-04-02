using System.Collections.Generic;
using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    public interface IEcoInquiryService
    {
        /// <summary>
        /// 分页查询生态询价单
        /// </summary>
        Task<PaginatedList<EcoInquiryDto>> GetInquiriesAsync(EcoInquiryQueryDto query);

        /// <summary>
        /// 获取询价单详情
        /// </summary>
        Task<EcoInquiryDto> GetInquiryDetailAsync(int id);

        /// <summary>
        /// 获取询价单分发记录
        /// </summary>
        Task<List<DistributionRecordDto>> GetDistributionRecordsAsync(int inquiryId);
    }
}
