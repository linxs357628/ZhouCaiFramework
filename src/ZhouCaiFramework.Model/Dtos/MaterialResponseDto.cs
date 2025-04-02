using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialResponseDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "材料 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "材料码不能为空")]
        [StringLength(50, ErrorMessage = "材料码长度不能超过 50 个字符")]
        public string Code { get; set; } // 材料码 (88.379+企业编码+材料编码)

        [Required(ErrorMessage = "类目名称不能为空")]
        [StringLength(50, ErrorMessage = "类目名称长度不能超过 50 个字符")]
        public string Category { get; set; } // 类目名称

        [StringLength(50, ErrorMessage = "二级类目名称长度不能超过 50 个字符")]
        public string SubCategory { get; set; } // 保留旧字段(二级类目名称)

        [Range(1, int.MaxValue, ErrorMessage = "子分类 ID 必须为正整数")]
        public int? SubCategoryId { get; set; } // 子分类ID

        [StringLength(50, ErrorMessage = "子分类名称长度不能超过 50 个字符")]
        public string SubCategoryName { get; set; } // 子分类名称(来自SubCategory实体)

        [Required(ErrorMessage = "品名不能为空")]
        [StringLength(100, ErrorMessage = "品名长度不能超过 100 个字符")]
        public string Name { get; set; } // 品名

        [StringLength(200, ErrorMessage = "规格长度不能超过 200 个字符")]
        public string Specification { get; set; } // 规格

        [Required(ErrorMessage = "基础单位不能为空")]
        [StringLength(20, ErrorMessage = "基础单位长度不能超过 20 个字符")]
        public string BaseUnit { get; set; } // 基础单位

        [StringLength(20, ErrorMessage = "二级单位长度不能超过 20 个字符")]
        public string SecondaryUnit { get; set; } // 二级单位

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "换算数值不能为负数")]
        public decimal ConversionRate { get; set; } // 换算数值

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "基础单位数量不能为负数")]
        public decimal Quantity { get; set; } // 数量(基础单位)

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "二级单位数量不能为负数")]
        public decimal SecondaryQuantity { get; set; } // 数量(二级单位)

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "重量不能为负数")]
        public decimal Weight { get; set; } // 重量(kg)

        public bool IsListed { get; set; } // 挂单状态

        [Required(ErrorMessage = "材料状态不能为空")]
        [StringLength(20, ErrorMessage = "材料状态长度不能超过 20 个字符")]
        public string Status { get; set; } // 材料状态(良品/报废)

        [Required(ErrorMessage = "周转状态不能为空")]
        [StringLength(20, ErrorMessage = "周转状态长度不能超过 20 个字符")]
        public string RentalStatus { get; set; } // 周转状态(租赁中/闲置中)

        [Required(ErrorMessage = "位置状态不能为空")]
        [StringLength(20, ErrorMessage = "位置状态长度不能超过 20 个字符")]
        public string LocationStatus { get; set; } // 位置状态(在仓库/在工地/在途中)

        [Range(0, int.MaxValue, ErrorMessage = "位置周期不能为负数")]
        public int LocationCycle { get; set; } // 位置周期

        [Required(ErrorMessage = "位置名称不能为空")]
        [StringLength(100, ErrorMessage = "位置名称长度不能超过 100 个字符")]
        public string LocationName { get; set; } // 位置名称

        [Range(1, int.MaxValue, ErrorMessage = "所属商家 ID 必须为正整数")]
        public int MerchantId { get; set; } // 所属商家ID

        [Required(ErrorMessage = "所属商家名称不能为空")]
        [StringLength(100, ErrorMessage = "所属商家名称长度不能超过 100 个字符")]
        public string MerchantName { get; set; } // 所属商家名称

        [Required(ErrorMessage = "初次上报时间不能为空")]
        public DateTime FirstReportTime { get; set; } // 初次上报时间

        [Required(ErrorMessage = "最后上报时间不能为空")]
        public DateTime LastReportTime { get; set; } // 最后上报时间

        [Required(ErrorMessage = "位置信息不能为空")]
        [StringLength(200, ErrorMessage = "位置信息长度不能超过 200 个字符")]
        public string Location { get; set; } // 位置信息

        [Url(ErrorMessage = "主图 URL 格式不正确")]
        [StringLength(200, ErrorMessage = "主图 URL 长度不能超过 200 个字符")]
        public string MainImage { get; set; } // 主图URL
    }

    public class MaterialStatsDto
    {
        // 总量统计
        [Range(0, int.MaxValue, ErrorMessage = "配码数量不能为负数")]
        public int TotalCount { get; set; } // 配码数量

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "总量不能为负数")]
        public decimal TotalQuantity { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "总重量不能为负数")]
        public decimal TotalWeight { get; set; }

        // 今日统计
        [Range(0, int.MaxValue, ErrorMessage = "今日新增数量不能为负数")]
        public int TodayNewCount { get; set; } // 今日新增

        [Range(0, int.MaxValue, ErrorMessage = "今日报废数量不能为负数")]
        public int TodayScrappedCount { get; set; } // 今日报废

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "今日新增重量不能为负数")]
        public decimal TodayNewWeight { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "今日报废重量不能为负数")]
        public decimal TodayScrappedWeight { get; set; }

        // 状态统计
        [Range(0, int.MaxValue, ErrorMessage = "良品数量不能为负数")]
        public int GoodCount { get; set; } // 良品数量

        [Range(0, int.MaxValue, ErrorMessage = "历史报废数量不能为负数")]
        public int ScrappedCount { get; set; } // 历史报废

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "良品重量不能为负数")]
        public decimal GoodWeight { get; set; } // 良品重量

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "报废重量不能为负数")]
        public decimal ScrappedWeight { get; set; } // 报废重量

        // 周转状态统计
        [Range(0, int.MaxValue, ErrorMessage = "租赁中数量不能为负数")]
        public int RentingCount { get; set; } // 租赁中数量

        [Range(0, int.MaxValue, ErrorMessage = "闲置中数量不能为负数")]
        public int IdleCount { get; set; } // 闲置中数量

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "租赁中重量不能为负数")]
        public decimal RentingWeight { get; set; } // 租赁中重量

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "闲置中重量不能为负数")]
        public decimal IdleWeight { get; set; } // 闲置中重量

        // 位置状态统计
        [Range(0, int.MaxValue, ErrorMessage = "在仓库数量不能为负数")]
        public int InWarehouseCount { get; set; } // 在仓库数量

        [Range(0, int.MaxValue, ErrorMessage = "在工地数量不能为负数")]
        public int OnSiteCount { get; set; } // 在工地数量

        [Range(0, int.MaxValue, ErrorMessage = "在途中数量不能为负数")]
        public int InTransitCount { get; set; } // 在途中数量

        [Range(0, int.MaxValue, ErrorMessage = "活跃材料数量不能为负数")]
        public int ActiveMaterials { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "报废材料数量不能为负数")]
        public int ScrappedMaterials { get; set; }
    }

    public class CategoryResponseDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "类目 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "类目名称不能为空")]
        [StringLength(50, ErrorMessage = "类目名称长度不能超过 50 个字符")]
        public string Name { get; set; } // 类目名称

        [StringLength(200, ErrorMessage = "类目描述长度不能超过 200 个字符")]
        public string Description { get; set; } // 类目描述
    }
}