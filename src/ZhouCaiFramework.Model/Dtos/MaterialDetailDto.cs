﻿﻿﻿﻿﻿﻿﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 材料明细数据传输对象
    /// </summary>
    public class MaterialDetailDto
    {
        [Required(ErrorMessage = "物料ID不能为空")]
        public int MaterialId { get; set; }

        [StringLength(100, ErrorMessage = "项目名称长度不能超过100个字符")]
        public string ProjectName { get; set; }

        [StringLength(50, ErrorMessage = "仓储编码长度不能超过50个字符")]
        public string StorageCode { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "锁库周期不能为负数")]
        public int LockPeriod { get; set; }
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
        [RegularExpression("^(正常|停用|报废)$", ErrorMessage = "状态必须为'正常','停用'或'报废'")]
        public string Status { get; set; }

        [Required(ErrorMessage = "位置状态不能为空")]
        [RegularExpression("^(在仓库|在工地|在途中)$", ErrorMessage = "位置状态必须为'在仓库','在工地'或'在途中'")]
        public string LocationStatus { get; set; }

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
        public object Remark { get; set; }
        public int PackageCount { get; set; }
        public decimal Quantity { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
