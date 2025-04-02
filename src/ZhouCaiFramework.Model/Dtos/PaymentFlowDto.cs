using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class PaymentFlowDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "流水记录 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "交易时间不能为空")]
        public DateTime TransactionTime { get; set; }

        [Required(ErrorMessage = "企业名称不能为空")]
        [StringLength(100, ErrorMessage = "企业名称长度不能超过 100 个字符")]
        public string EnterpriseName { get; set; }

        [Required(ErrorMessage = "企业级别不能为空")]
        [StringLength(20, ErrorMessage = "企业级别长度不能超过 20 个字符")]
        public string EnterpriseLevel { get; set; } // 总公司/分子公司

        [Required(ErrorMessage = "流水类型不能为空")]
        [StringLength(10, ErrorMessage = "流水类型长度不能超过 10 个字符")]
        public string FlowType { get; set; } // 收入/支出

        [Required(ErrorMessage = "业务类型不能为空")]
        [StringLength(50, ErrorMessage = "业务类型长度不能超过 50 个字符")]
        public string BusinessType { get; set; } // 业务类型

        [Range(0, decimal.MaxValue, ErrorMessage = "交易金额不能为负数")]
        public decimal Amount { get; set; } // 交易金额

        [Range(0, decimal.MaxValue, ErrorMessage = "操作后余额不能为负数")]
        public decimal BalanceAfter { get; set; } // 操作后余额

        [Required(ErrorMessage = "流水号不能为空")]
        [StringLength(50, ErrorMessage = "流水号长度不能超过 50 个字符")]
        public string FlowNumber { get; set; } // 流水号
    }
}