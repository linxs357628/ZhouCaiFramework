using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialQueryDto
    {
        [StringLength(100, ErrorMessage = "关键字长度不能超过 100 个字符")]
        public string Keyword { get; set; }

        [StringLength(50, ErrorMessage = "类目长度不能超过 50 个字符")]
        public string Category { get; set; }

        [StringLength(50, ErrorMessage = "二级类目长度不能超过 50 个字符")]
        public string SubCategory { get; set; } // 二级类目

        [StringLength(100, ErrorMessage = "名称长度不能超过 100 个字符")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "规格长度不能超过 200 个字符")]
        public string Specification { get; set; }

        public bool? IsListed { get; set; }

        [StringLength(50, ErrorMessage = "状态长度不能超过 50 个字符")]
        public string Status { get; set; }

        [StringLength(50, ErrorMessage = "周转状态长度不能超过 50 个字符")]
        public string RentalStatus { get; set; } // 周转状态: 租赁中/闲置中

        [StringLength(50, ErrorMessage = "位置状态长度不能超过 50 个字符")]
        public string LocationStatus { get; set; } // 位置状态: 在仓库/在工地/在途中

        public int? MerchantId { get; set; } // 所属商家ID

        [Range(typeof(DateTime), "01/01/1900", "12/31/9999", ErrorMessage = "首次报告开始时间必须在有效范围内")]
        public DateTime? FirstReportStart { get; set; }

        [Range(typeof(DateTime), "01/01/1900", "12/31/9999", ErrorMessage = "首次报告结束时间必须在有效范围内")]
        public DateTime? FirstReportEnd { get; set; }

        [Range(typeof(DateTime), "01/01/1900", "12/31/9999", ErrorMessage = "上次报告开始时间必须在有效范围内")]
        public DateTime? LastReportStart { get; set; }

        [Range(typeof(DateTime), "01/01/1900", "12/31/9999", ErrorMessage = "上次报告结束时间必须在有效范围内")]
        public DateTime? LastReportEnd { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "最小位置周期不能为负数")]
        public int? MinLocationCycle { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "最大位置周期不能为负数")]
        public int? MaxLocationCycle { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "页码必须大于 0")]
        public int PageIndex { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "每页数量必须在 1 到 100 之间")]
        public int PageSize { get; set; } = 20;
    }
}