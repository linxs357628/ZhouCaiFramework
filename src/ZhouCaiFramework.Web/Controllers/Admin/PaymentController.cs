using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 收款管理
    /// </summary>

    public class PaymentController : AdminBaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(
            IPaymentService paymentService,
            ILogger<PaymentController> logger) : base(logger)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentCreateDto dto)
        {
            // 自动计算价税合计
            dto.TotalAmount = dto.TaxExcludedAmount + dto.TaxAmount;

            // 验证必填字段
            if (string.IsNullOrEmpty(dto.PayerName) ||
                string.IsNullOrEmpty(dto.ReceiverName))
            {
                return BadRequest("付款单位和收款单位不能为空");
            }

            var result = await _paymentService.AddPayment(dto);

            // 异步同步到财务系统
            if (result)
            {
                _ = Task.Run(async () =>
                {
                    await SyncToFinanceSystem(dto);
                });
            }

            return Success(result);
        }

        private async Task<bool> SyncToFinanceSystem(PaymentCreateDto dto)
        {
            // TODO: 实现财务系统同步逻辑
            // 这里可以调用金蝶等财务系统的API
            await Task.Delay(100); // 模拟网络请求

            // 更新同步状态
            await _paymentService.UpdateSyncStatus(dto);
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments([FromQuery] PaymentQuery query)
        {
            var result = await _paymentService.GetPayments(query);
            return Success(result);
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportPayments([FromQuery] PaymentQuery query)
        {
            var fileBytes = await _paymentService.ExportPayments(query);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "收款记录.xlsx");
        }

        [HttpPost("{paymentId}/invoice")]
        public async Task<IActionResult> LinkInvoice(int paymentId, [FromBody] InvoiceLinkDto dto)
        {
            var result = await _paymentService.LinkInvoice(paymentId, dto);
            return Success(result);
        }
    }
}