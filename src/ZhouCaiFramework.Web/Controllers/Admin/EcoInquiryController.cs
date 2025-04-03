using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 采购询价控制器
    /// </summary>

    public class EcoInquiryController : AdminBaseController
    {
        private readonly IEcoInquiryService _ecoInquiryService;

        public EcoInquiryController(IEcoInquiryService ecoInquiryService, ILogger<EcoInquiryController> logger) : base(logger)
        {
            _ecoInquiryService = ecoInquiryService;
        }

        /// <summary>
        /// 获取采购询价列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetInquiries([FromQuery] EcoInquiryQueryDto query)
        {
            var result = await _ecoInquiryService.GetInquiriesAsync(query);
            return Success(result);
        }

        /// <summary>
        /// 获取采购询价详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInquiryDetail(int id)
        {
            var result = await _ecoInquiryService.GetInquiryDetailAsync(id);
            return Success(result);
        }

        /// <summary>
        /// 获取询价单分发记录
        /// </summary>
        /// <param name="inquiryId"></param>
        /// <returns></returns>
        [HttpGet("{inquiryId}/distributions")]
        public async Task<IActionResult> GetDistributionRecords(int inquiryId)
        {
            var result = await _ecoInquiryService.GetDistributionRecordsAsync(inquiryId);
            return Success(result);
        }
    }
}