using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class PaymentFlowDetailDto : PaymentFlowDto
    {
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "原始金额不能为负数")]
        public decimal OriginalAmount { get; set; } // 原始金额

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "实际金额不能为负数")]
        public decimal ActualAmount { get; set; } // 实际金额

        [StringLength(2000, ErrorMessage = "关联订单信息长度不能超过 2000 个字符")]
        public string RelatedOrder { get; set; } // 关联订单信息(json)
    }
}