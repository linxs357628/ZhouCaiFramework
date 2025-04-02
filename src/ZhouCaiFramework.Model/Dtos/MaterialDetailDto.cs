using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialDetailDto
    {
        [Required(ErrorMessage = "物料编码不能为空")]
        [StringLength(50, ErrorMessage = "物料编码长度不能超过 50 个字符")]
        public string MaterialCode { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [StringLength(50, ErrorMessage = "类别长度不能超过 50 个字符")]
        public string Category { get; set; }

        [Required(ErrorMessage = "物料名称不能为空")]
        [StringLength(100, ErrorMessage = "物料名称长度不能超过 100 个字符")]
        public string MaterialName { get; set; }

        [StringLength(200, ErrorMessage = "规格长度不能超过 200 个字符")]
        public string Specification { get; set; }

        [Required(ErrorMessage = "所有者不能为空")]
        [StringLength(50, ErrorMessage = "所有者长度不能超过 50 个字符")]
        public string Owner { get; set; }

        public bool IsPending { get; set; }

        public bool IsMortgaged { get; set; }

        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime CreateTime { get; set; }

        [StringLength(200, ErrorMessage = "最新结果长度不能超过 200 个字符")]
        public string LatestResult { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "重量不能为负数")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [StringLength(50, ErrorMessage = "状态长度不能超过 50 个字符")]
        public string Status { get; set; }

        [Required(ErrorMessage = "当前位置不能为空")]
        [StringLength(100, ErrorMessage = "当前位置长度不能超过 100 个字符")]
        public string CurrentLocation { get; set; }

        [Required(ErrorMessage = "位置名称不能为空")]
        [StringLength(100, ErrorMessage = "位置名称长度不能超过 100 个字符")]
        public string LocationName { get; set; }

        [Required(ErrorMessage = "上次报告时间不能为空")]
        public DateTime LastReportTime { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "位置周期不能为负数")]
        public int LocationPeriod { get; set; }
    }
}