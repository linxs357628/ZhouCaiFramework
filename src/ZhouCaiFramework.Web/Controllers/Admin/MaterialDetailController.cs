using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class MaterialDetailController : AdminBaseController
    {
        private readonly IMaterialDetailService _materialDetailService;

        public MaterialDetailController(
            IMaterialDetailService materialDetailService,
            ILogger<MaterialDetailController> logger) : base(null, logger)
        {
            _materialDetailService = materialDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(
            int materialId,
            [FromQuery] string keyword,
            [FromQuery] List<string> categories,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] List<string> statuses,
            [FromQuery] int? minDays,
            [FromQuery] int? maxDays,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            var result = await _materialDetailService.GetDetails(
                materialId,
                keyword,
                categories,
                startDate,
                endDate,
                statuses,
                minDays,
                maxDays,
                page,
                pageSize);

            return Ok(new
            {
                Total = result.TotalCount,
                Items = result.Items.Select(x => new MaterialDetailDto
                {
                    MaterialCode = x.MaterialCode,
                    Category = x.Category,
                    MaterialName = x.MaterialName,
                    Specification = x.Specification,
                    Owner = x.Owner,
                    IsPending = x.IsPending,
                    IsMortgaged = x.IsMortgaged,
                    CreateTime = x.CreateTime,
                    LatestResult = x.LatestResult,
                    Weight = x.Weight,
                    Status = x.Status,
                    CurrentLocation = x.CurrentLocation,
                    LocationName = x.LocationName,
                    LastReportTime = x.LastReportTime,
                    LocationPeriod = x.LocationPeriod
                })
            });
        }

        [HttpGet("{materialCode}/history")]
        public async Task<IActionResult> GetHistory(string materialCode)
        {
            var history = await _materialDetailService.GetMaterialHistory(materialCode);
            return Ok(history);
        }
    }
}