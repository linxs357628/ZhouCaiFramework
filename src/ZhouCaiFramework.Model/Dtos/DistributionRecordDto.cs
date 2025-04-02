using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class DistributionRecordDto
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "询价记录 ID 必须为正整数")]
        public int InquiryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "商户 ID 必须为正整数")]
        public int MerchantId { get; set; }

        [Required(ErrorMessage = "商户名称不能为空")]
        [StringLength(100, ErrorMessage = "商户名称长度不能超过 100 个字符")]
        public string MerchantName { get; set; }

        [Required(ErrorMessage = "分配时间不能为空")]
        public DateTime DistributionTime { get; set; }

        [StringLength(500, ErrorMessage = "备注长度不能超过 500 个字符")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [StringLength(50, ErrorMessage = "状态长度不能超过 50 个字符")]
        public string Status { get; set; }

        public DateTime? ResponseTime { get; set; }

        [StringLength(1000, ErrorMessage = "响应内容长度不能超过 1000 个字符")]
        public string ResponseContent { get; set; }
    }
}