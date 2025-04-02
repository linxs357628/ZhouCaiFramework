using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class EcoInquiryController : ControllerBase
    {
        private readonly IEcoInquiryService _ecoInquiryService;

        public EcoInquiryController(IEcoInquiryService ecoInquiryService)
        {
            _ecoInquiryService = ecoInquiryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInquiries([FromQuery] EcoInquiryQueryDto query)
        {
            var result = await _ecoInquiryService.GetInquiriesAsync(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInquiryDetail(int id)
        {
            var result = await _ecoInquiryService.GetInquiryDetailAsync(id);
            return Ok(result);
        }

        [HttpGet("{inquiryId}/distributions")]
        public async Task<IActionResult> GetDistributionRecords(int inquiryId)
        {
            var result = await _ecoInquiryService.GetDistributionRecordsAsync(inquiryId);
            return Ok(result);
        }
    }
}