using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class EcoInquiryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "询价时间不能为空")]
        public DateTime InquiryTime { get; set; }

        [Required(ErrorMessage = "询价人姓名不能为空")]
        [StringLength(50, ErrorMessage = "询价人姓名长度不能超过 50 个字符")]
        public string InquirerName { get; set; }

        [Required(ErrorMessage = "入口点不能为空")]
        [StringLength(100, ErrorMessage = "入口点长度不能超过 100 个字符")]
        public string EntryPoint { get; set; }

        [Required(ErrorMessage = "询价类型不能为空")]
        [StringLength(50, ErrorMessage = "询价类型长度不能超过 50 个字符")]
        public string InquiryType { get; set; }

        [Required(ErrorMessage = "询价项目列表不能为空")]
        public List<InquiryItemDto> Items { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "项目数量不能为负数")]
        public int ItemCount { get; set; }

        [StringLength(20, ErrorMessage = "单位长度不能超过 20 个字符")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "联系信息不能为空")]
        [StringLength(100, ErrorMessage = "联系信息长度不能超过 100 个字符")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "交货地址不能为空")]
        [StringLength(200, ErrorMessage = "交货地址长度不能超过 200 个字符")]
        public string DeliveryAddress { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "分配数量不能为负数")]
        public int DistributionCount { get; set; }

        [StringLength(100, ErrorMessage = "标签长度不能超过 100 个字符")]
        public string Tags { get; set; }
    }

    public class InquiryItemDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "物料 ID 必须为正整数")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "物料名称不能为空")]
        [StringLength(100, ErrorMessage = "物料名称长度不能超过 100 个字符")]
        public string MaterialName { get; set; }

        [StringLength(200, ErrorMessage = "规格长度不能超过 200 个字符")]
        public string Specification { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "数量不能为负数")]
        public decimal Quantity { get; set; }

        [StringLength(20, ErrorMessage = "单位长度不能超过 20 个字符")]
        public string Unit { get; set; }

        [StringLength(500, ErrorMessage = "备注长度不能超过 500 个字符")]
        public string Remarks { get; set; }
    }
}