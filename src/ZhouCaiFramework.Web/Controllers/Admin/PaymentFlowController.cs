using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 支付流水管理
    /// </summary>

    public class PaymentFlowController : AdminBaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentFlowController(
            IPaymentService paymentService,
            ILogger<PaymentFlowController> logger) : base(logger)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentFlow(
            [FromBody] PaymentCreateDto dto)
        {
            try
            {
                var flow = dto.Adapt<PaymentFlow>();

                var result = await _paymentService.CreatePaymentFlowAsync(flow);
                return CreatedAtAction(nameof(GetFlowDetail), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建支付流水失败");
                return Fail<IActionResult>("创建支付流水失败");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlowDetail(
            [Range(1, int.MaxValue)] int id)
        {
            try
            {
                var flow = await _paymentService.GetFlowDetailAsync(id);
                return flow != null ? Success(flow) : NotFound<PaymentFlow>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取流水详情失败");
                return Fail<PaymentFlow>("获取流水详情失败");
            }
        }

        [HttpGet("query")]
        public async Task<IActionResult> QueryFlows(
            [FromQuery] PaymentQuery query)
        {
            try
            {
                var (records, totalCount) = await _paymentService.QueryFlowsAsync(
                    query.MerchantId,
                    query.StartTime,
                    query.EndTime,
                    query.FlowType,
                    query.BusinessType,
                    query.EnterpriseName,
                    query.FlowNumber,
                    query.MinAmount,
                    query.MaxAmount,
                    query.PageIndex,
                    query.PageSize);

                return Success(new PaginatedList<PaymentFlow>(
                    records.ToList(),
                    totalCount,
                    query.PageIndex,
                    query.PageSize));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "查询支付流水失败");
                return Fail<PaginatedList<PaymentFlow>>("查询支付流水失败");
            }
        }
    }
}