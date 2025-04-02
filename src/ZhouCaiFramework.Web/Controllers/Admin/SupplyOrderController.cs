using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 供应商订单管理
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    public class SupplyOrderController : AdminBaseController
    {
        public SupplyOrderController(ISqlSugarClient db, ILogger<AdminBaseController> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// 获取询价订单
        /// </summary>
        /// <returns></returns>
        [HttpGet("inquiry-orders")]
        public IActionResult GetInquiryOrders()
        {
            // TODO: Implement inquiry orders
            return Ok(new[] { new { Id = 1, InquiryNo = "INQ-ADMIN-001" } });
        }

        /// <summary>
        /// 获取供应商库存
        /// </summary>
        /// <returns></returns>
        [HttpGet("lessor-inventory")]
        public IActionResult GetLessorInventory()
        {
            // TODO: Implement lessor inventory
            return Ok(new[] { new { Id = 1, Lessor = "Company A", Material = "Scaffolding" } });
        }

        /// <summary>
        /// 获取转移订单
        /// </summary>
        /// <returns></returns>
        [HttpGet("transfer-orders")]
        public IActionResult GetTransferOrders()
        {
            // TODO: Implement transfer orders
            return Ok(new[] { new { Id = 1, OrderNo = "TRF-001" } });
        }
    }
}