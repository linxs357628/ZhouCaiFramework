using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class ManualPaymentRecordDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "记录 ID 必须为正整数")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "项目 ID 必须为正整数")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "付款类型不能为空")]
        [StringLength(50, ErrorMessage = "付款类型长度不能超过 50 个字符")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "付款时间不能为空")]
        public DateTime PaymentTime { get; set; }

        [Required(ErrorMessage = "货币类型不能为空")]
        [StringLength(20, ErrorMessage = "货币类型长度不能超过 20 个字符")]
        public string CurrencyType { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "付款金额必须大于 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "流水号不能为空")]
        [StringLength(50, ErrorMessage = "流水号长度不能超过 50 个字符")]
        public string FlowNumber { get; set; }

        // 收款账户信息
        [Required(ErrorMessage = "收款方名称不能为空")]
        [StringLength(100, ErrorMessage = "收款方名称长度不能超过 100 个字符")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "收款方银行不能为空")]
        [StringLength(100, ErrorMessage = "收款方银行长度不能超过 100 个字符")]
        public string ReceiverBank { get; set; }

        [Required(ErrorMessage = "收款方账号不能为空")]
        [StringLength(50, ErrorMessage = "收款方账号长度不能超过 50 个字符")]
        public string ReceiverAccount { get; set; }

        [StringLength(50, ErrorMessage = "收款方税号长度不能超过 50 个字符")]
        public string ReceiverTaxId { get; set; }

        // 付款账户信息
        [Required(ErrorMessage = "付款方名称不能为空")]
        [StringLength(100, ErrorMessage = "付款方名称长度不能超过 100 个字符")]
        public string PayerName { get; set; }

        [Required(ErrorMessage = "付款方银行不能为空")]
        [StringLength(100, ErrorMessage = "付款方银行长度不能超过 100 个字符")]
        public string PayerBank { get; set; }

        [Required(ErrorMessage = "付款方账号不能为空")]
        [StringLength(50, ErrorMessage = "付款方账号长度不能超过 50 个字符")]
        public string PayerAccount { get; set; }

        [StringLength(50, ErrorMessage = "付款方税号长度不能超过 50 个字符")]
        public string PayerTaxId { get; set; }

        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime CreateTime { get; set; }

        [Required(ErrorMessage = "创建人不能为空")]
        [StringLength(50, ErrorMessage = "创建人姓名长度不能超过 50 个字符")]
        public string Creator { get; set; }

        [StringLength(200, ErrorMessage = "备注长度不能超过 200 个字符")]
        public string Remark { get; set; }
    }

    public class CreateManualPaymentRecordDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "项目 ID 必须为正整数")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "付款类型不能为空")]
        [StringLength(50, ErrorMessage = "付款类型长度不能超过 50 个字符")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "付款时间不能为空")]
        public DateTime PaymentTime { get; set; }

        [Required(ErrorMessage = "货币类型不能为空")]
        [StringLength(20, ErrorMessage = "货币类型长度不能超过 20 个字符")]
        public string CurrencyType { get; set; }

        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "付款金额必须大于 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "流水号不能为空")]
        [StringLength(50, ErrorMessage = "流水号长度不能超过 50 个字符")]
        public string FlowNumber { get; set; }

        [Required(ErrorMessage = "收款方名称不能为空")]
        [StringLength(100, ErrorMessage = "收款方名称长度不能超过 100 个字符")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "收款方银行不能为空")]
        [StringLength(100, ErrorMessage = "收款方银行长度不能超过 100 个字符")]
        public string ReceiverBank { get; set; }

        [Required(ErrorMessage = "收款方账号不能为空")]
        [StringLength(50, ErrorMessage = "收款方账号长度不能超过 50 个字符")]
        public string ReceiverAccount { get; set; }

        [StringLength(50, ErrorMessage = "收款方税号长度不能超过 50 个字符")]
        public string ReceiverTaxId { get; set; }

        [Required(ErrorMessage = "付款方名称不能为空")]
        [StringLength(100, ErrorMessage = "付款方名称长度不能超过 100 个字符")]
        public string PayerName { get; set; }

        [Required(ErrorMessage = "付款方银行不能为空")]
        [StringLength(100, ErrorMessage = "付款方银行长度不能超过 100 个字符")]
        public string PayerBank { get; set; }

        [Required(ErrorMessage = "付款方账号不能为空")]
        [StringLength(50, ErrorMessage = "付款方账号长度不能超过 50 个字符")]
        public string PayerAccount { get; set; }

        [StringLength(50, ErrorMessage = "付款方税号长度不能超过 50 个字符")]
        public string PayerTaxId { get; set; }

        [StringLength(200, ErrorMessage = "备注长度不能超过 200 个字符")]
        public string Remark { get; set; }
    }

    public class UpdateManualPaymentRecordDto
    {
        [Required(ErrorMessage = "付款类型不能为空")]
        [StringLength(50, ErrorMessage = "付款类型长度不能超过 50 个字符")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "付款时间不能为空")]
        public DateTime PaymentTime { get; set; }

        [Required(ErrorMessage = "货币类型不能为空")]
        [StringLength(20, ErrorMessage = "货币类型长度不能超过 20 个字符")]
        public string CurrencyType { get; set; }

        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "付款金额必须大于 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "流水号不能为空")]
        [StringLength(50, ErrorMessage = "流水号长度不能超过 50 个字符")]
        public string FlowNumber { get; set; }

        [Required(ErrorMessage = "收款方名称不能为空")]
        [StringLength(100, ErrorMessage = "收款方名称长度不能超过 100 个字符")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "收款方银行不能为空")]
        [StringLength(100, ErrorMessage = "收款方银行长度不能超过 100 个字符")]
        public string ReceiverBank { get; set; }

        [Required(ErrorMessage = "收款方账号不能为空")]
        [StringLength(50, ErrorMessage = "收款方账号长度不能超过 50 个字符")]
        public string ReceiverAccount { get; set; }

        [StringLength(50, ErrorMessage = "收款方税号长度不能超过 50 个字符")]
        public string ReceiverTaxId { get; set; }

        [Required(ErrorMessage = "付款方名称不能为空")]
        [StringLength(100, ErrorMessage = "付款方名称长度不能超过 100 个字符")]
        public string PayerName { get; set; }

        [Required(ErrorMessage = "付款方银行不能为空")]
        [StringLength(100, ErrorMessage = "付款方银行长度不能超过 100 个字符")]
        public string PayerBank { get; set; }

        [Required(ErrorMessage = "付款方账号不能为空")]
        [StringLength(50, ErrorMessage = "付款方账号长度不能超过 50 个字符")]
        public string PayerAccount { get; set; }

        [StringLength(50, ErrorMessage = "付款方税号长度不能超过 50 个字符")]
        public string PayerTaxId { get; set; }

        [StringLength(200, ErrorMessage = "备注长度不能超过 200 个字符")]
        public string Remark { get; set; }
    }
}