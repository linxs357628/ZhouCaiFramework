using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 创建支付流水数据传输对象
    /// </summary>
    public class PaymentCreateDto
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        [Required(ErrorMessage = "商家ID不能为空")]
        [Range(1, int.MaxValue, ErrorMessage = "商家ID必须大于0")]
        public int MerchantId { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        [Required(ErrorMessage = "交易时间不能为空")]
        public DateTime TransactionTime { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [Required(ErrorMessage = "企业名称不能为空")]
        [StringLength(100, ErrorMessage = "企业名称长度不能超过100个字符")]
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 企业级别
        /// </summary>
        [StringLength(20, ErrorMessage = "企业级别长度不能超过20个字符")]
        public string EnterpriseLevel { get; set; }

        /// <summary>
        /// 流水类型(income/expenditure)
        /// </summary>
        [Required(ErrorMessage = "流水类型不能为空")]
        [StringLength(20, ErrorMessage = "流水类型长度不能超过20个字符")]
        public string FlowType { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [StringLength(50, ErrorMessage = "业务类型长度不能超过50个字符")]
        public string BusinessType { get; set; }

        /// <summary>
        /// 原始金额
        /// </summary>
        [Required(ErrorMessage = "原始金额不能为空")]
        [Range(0, double.MaxValue, ErrorMessage = "原始金额必须大于等于0")]
        public decimal OriginalAmount { get; set; }

        /// <summary>
        /// 实际金额
        /// </summary>
        [Required(ErrorMessage = "实际金额不能为空")]
        [Range(0, double.MaxValue, ErrorMessage = "实际金额必须大于等于0")]
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [Required(ErrorMessage = "流水号不能为空")]
        [StringLength(50, ErrorMessage = "流水号长度不能超过50个字符")]
        public string FlowNumber { get; set; }

        /// <summary>
        /// 关联订单信息(JSON格式)
        /// </summary>
        [StringLength(500, ErrorMessage = "关联订单信息长度不能超过500个字符")]
        public string RelatedOrder { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string Remark { get; set; }

        public int TaxExcludedAmount { get; set; }
        public int TaxAmount { get; set; }
        public int TotalAmount { get; set; }
        public string PayerName { get; set; }
        public string ReceiverName { get; set; }
    }
}