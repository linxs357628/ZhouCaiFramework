using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// ���Ͽ��
    /// </summary>

    public class MaterialInventoryController : AdminBaseController
    {
        private readonly IMaterialInventoryService _materialService;

        public MaterialInventoryController(
            IMaterialInventoryService materialService,
            ILogger<MaterialInventoryController> logger) : base(logger)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// ��ȡ���Ͽ��
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="orderTypes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="paymentStatus"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetInventory(
            [FromQuery] string keyword,
            [FromQuery] List<string> orderTypes,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] string paymentStatus,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            var result = await _materialService.GetInventory(
                keyword,
                orderTypes,
                startDate,
                endDate,
                paymentStatus,
                page,
                pageSize);

            return Success(new
            {
                Total = result.TotalCount,
                Items = result.Items.Select(x => new MaterialInventoryDto
                {
                    Category = x.Category,
                    MaterialName = x.MaterialName,
                    ReferencePrice = x.ReferencePrice,
                    Specification = x.Specification,
                    TotalQuantity = x.TotalQuantity,
                    TotalWeight = x.TotalWeight,
                    OwnQuantity = x.OwnQuantity,
                    OwnWeight = x.OwnWeight,
                    ClientCount = x.ClientCount,
                    ClientQuantity = x.ClientQuantity,
                    ClientWeight = x.ClientWeight,
                    OnSiteQuantity = x.OnSiteQuantity,
                    OnSiteWeight = x.OnSiteWeight,
                    OwnOnSiteQuantity = x.OwnOnSiteQuantity,
                    OwnOnSiteWeight = x.OwnOnSiteWeight,
                    ClientOnSiteQuantity = x.ClientOnSiteQuantity,
                    ClientOnSiteWeight = x.ClientOnSiteWeight
                })
            });
        }
    }
}