using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 财务
    /// </summary>

    public class FinancialDataController : AdminBaseController
    {
        public FinancialDataController(ISqlSugarClient db, ILogger<AdminBaseController> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// 获取商户交易明细
        /// </summary>
        /// <returns></returns>
        [HttpGet("merchant-transactions")]
        public IActionResult GetMerchantTransactions()
        {
            // TODO: Implement merchant transaction details
            return Ok(new[] { new { Id = 1, Merchant = "Company A", Amount = 5000 } });
        }

        /// <summary>
        /// 获取日交易明细
        /// </summary>
        /// <returns></returns>
        [HttpGet("daily-details")]
        public IActionResult GetDailyTransactionDetails()
        {
            // TODO: Implement daily transaction details
            return Ok(new[] { new { Date = "2025-03-31", Income = 10000, Expense = 3000 } });
        }
    }
}