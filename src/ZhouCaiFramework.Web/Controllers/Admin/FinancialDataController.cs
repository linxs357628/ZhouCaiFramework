using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// ����
    /// </summary>

    public class FinancialDataController : AdminBaseController
    {
        public FinancialDataController(ISqlSugarClient db, ILogger<AdminBaseController> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// ��ȡ�̻�������ϸ
        /// </summary>
        /// <returns></returns>
        [HttpGet("merchant-transactions")]
        public IActionResult GetMerchantTransactions()
        {
            // TODO: Implement merchant transaction details
            return Success(new[] { new { Id = 1, Merchant = "Company A", Amount = 5000 } });
        }

        /// <summary>
        /// ��ȡ�ս�����ϸ
        /// </summary>
        /// <returns></returns>
        [HttpGet("daily-details")]
        public IActionResult GetDailyTransactionDetails()
        {
            // TODO: Implement daily transaction details
            return Success(new[] { new { Date = "2025-03-31", Income = 10000, Expense = 3000 } });
        }
    }
}