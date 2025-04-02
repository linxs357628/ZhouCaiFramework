using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class ManualPaymentController : AdminBaseController
    {
        private readonly IManualPaymentService _paymentService;

        public ManualPaymentController(
            IManualPaymentService paymentService,
            ILogger<ManualPaymentController> logger) : base(null, logger)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateManualPaymentRecordDto dto)
        {
            var record = new ManualPaymentRecord
            {
                ProjectId = dto.ProjectId,
                PaymentType = dto.PaymentType,
                PaymentTime = dto.PaymentTime,
                CurrencyType = dto.CurrencyType,
                Amount = dto.Amount,
                FlowNumber = dto.FlowNumber,
                ReceiverName = dto.ReceiverName,
                ReceiverBank = dto.ReceiverBank,
                ReceiverAccount = dto.ReceiverAccount,
                ReceiverTaxId = dto.ReceiverTaxId,
                PayerName = dto.PayerName,
                PayerBank = dto.PayerBank,
                PayerAccount = dto.PayerAccount,
                PayerTaxId = dto.PayerTaxId,
                Remark = dto.Remark,
                Creator = User.Identity.Name
            };

            var result = await _paymentService.CreateAsync(record);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateManualPaymentRecordDto dto)
        {
            var record = await _paymentService.GetByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            record.PaymentType = dto.PaymentType;
            record.PaymentTime = dto.PaymentTime;
            record.CurrencyType = dto.CurrencyType;
            record.Amount = dto.Amount;
            record.FlowNumber = dto.FlowNumber;
            record.ReceiverName = dto.ReceiverName;
            record.ReceiverBank = dto.ReceiverBank;
            record.ReceiverAccount = dto.ReceiverAccount;
            record.ReceiverTaxId = dto.ReceiverTaxId;
            record.PayerName = dto.PayerName;
            record.PayerBank = dto.PayerBank;
            record.PayerAccount = dto.PayerAccount;
            record.PayerTaxId = dto.PayerTaxId;
            record.Remark = dto.Remark;

            var result = await _paymentService.UpdateAsync(record);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _paymentService.DeleteAsync(id);
            return success ? Ok() : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _paymentService.GetByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetByProject(int projectId)
        {
            var records = await _paymentService.GetByProjectAsync(projectId);
            return Ok(records);
        }
    }
}