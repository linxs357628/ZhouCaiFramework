using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Common.Validations;

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
        [DateLessThan(nameof(EndTime), ErrorMessage = "开始时间不能晚于结束时间")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DateGreaterThan(nameof(StartTime), ErrorMessage = "结束时间不能早于开始时间")]
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
        /// 流水类型(1:收入/2:支出)
        /// </summary>
        [RegularExpression("^[12]$", ErrorMessage = "流水类型必须为1(收入)或2(支出)")]
        public string FlowType { get; set; }

        /// <summary>
        /// 状态(0:待审核/1:已通过/2:已拒绝)
        /// </summary>
        [RegularExpression("^[012]$", ErrorMessage = "状态必须为0(待审核)/1(已通过)/2(已拒绝)")]
        public string Status { get; set; }

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