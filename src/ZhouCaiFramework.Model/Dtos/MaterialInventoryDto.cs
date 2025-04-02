using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialInventoryDto
    {
        [Required(ErrorMessage = "类别不能为空")]
        [StringLength(50, ErrorMessage = "类别长度不能超过 50 个字符")]
        public string Category { get; set; }

        [Required(ErrorMessage = "物料名称不能为空")]
        [StringLength(100, ErrorMessage = "物料名称长度不能超过 100 个字符")]
        public string MaterialName { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "参考价格不能为负数")]
        public decimal? ReferencePrice { get; set; }

        [StringLength(200, ErrorMessage = "规格长度不能超过 200 个字符")]
        public string Specification { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "总数量不能为负数")]
        public decimal TotalQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "总重量不能为负数")]
        public decimal TotalWeight { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "自有数量不能为负数")]
        public decimal OwnQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "自有重量不能为负数")]
        public decimal OwnWeight { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "客户数量不能为负数")]
        public int ClientCount { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "客户数量不能为负数")]
        public decimal ClientQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "客户重量不能为负数")]
        public decimal ClientWeight { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "现场数量不能为负数")]
        public decimal OnSiteQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "现场重量不能为负数")]
        public decimal OnSiteWeight { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "自有现场数量不能为负数")]
        public decimal OwnOnSiteQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "自有现场重量不能为负数")]
        public decimal OwnOnSiteWeight { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "客户现场数量不能为负数")]
        public decimal ClientOnSiteQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "客户现场重量不能为负数")]
        public decimal ClientOnSiteWeight { get; set; }
    }
}