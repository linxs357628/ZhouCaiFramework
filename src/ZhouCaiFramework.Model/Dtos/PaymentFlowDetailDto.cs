using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 支付流水详情DTO
    /// 包含支付流水的详细信息和操作记录
    /// </summary>
    public class PaymentFlowDetailDto : PaymentFlowDto
    {
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "原始金额不能为负数")]
        public decimal OriginalAmount { get; set; } // 原始金额

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "实际金额不能为负数")]
        public decimal ActualAmount { get; set; } // 实际金额

        [StringLength(2000, ErrorMessage = "关联订单信息长度不能超过 2000 个字符")]
        [RegularExpression(@"^\s*(\{.*\}|\[.*\])\s*$", ErrorMessage = "关联订单信息必须是有效的JSON格式")]
        public string RelatedOrder { get; set; } // 关联订单信息(json)

        [Required(ErrorMessage = "操作时间不能为空")]
        public DateTime OperationTime { get; set; }

        [StringLength(500, ErrorMessage = "操作备注长度不能超过500个字符")]
        public string OperationRemark { get; set; }
    }
}
