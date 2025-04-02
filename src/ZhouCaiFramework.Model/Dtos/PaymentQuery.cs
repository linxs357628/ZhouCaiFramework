using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 支付流水查询条件
    /// </summary>
    public class PaymentQuery
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "商家ID必须大于0")]
        public int? MerchantId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 最小金额
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "最小金额不能小于0")]
        public decimal? MinAmount { get; set; }

        /// <summary>
        /// 最大金额
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "最大金额不能小于0")]
        public decimal? MaxAmount { get; set; }

        /// <summary>
        /// 流水类型(income/expenditure)
        /// </summary>
        [StringLength(20, ErrorMessage = "流水类型长度不能超过20个字符")]
        public string FlowType { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [StringLength(50, ErrorMessage = "业务类型长度不能超过50个字符")]
        public string BusinessType { get; set; }

        /// <summary>
        /// 企业名称(模糊查询)
        /// </summary>
        [StringLength(100, ErrorMessage = "企业名称长度不能超过100个字符")]
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 流水号(精确查询)
        /// </summary>
        [StringLength(50, ErrorMessage = "流水号长度不能超过50个字符")]
        public string FlowNumber { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Range(1, 1000, ErrorMessage = "页码必须在1-1000之间")]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页数量
        /// </summary>
        [Range(1, 100, ErrorMessage = "每页数量必须在1-100之间")]
        public int PageSize { get; set; } = 20;
    }
}