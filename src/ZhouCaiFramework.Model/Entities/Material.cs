using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 材料
    /// </summary>
    public class Material
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Code { get; set; } // 材料码

        [SugarColumn(IsNullable = true)]
        public int? CategoryId { get; set; } // 类目

        public string Category { get; set; }
        public string Name { get; set; } // 品名

        public string Specification { get; set; } // 规格

        public string BaseUnit { get; set; } // 基础单位

        public string SecondaryUnit { get; set; } // 二级单位

        public decimal ConversionRate { get; set; } // 换算数值

        public decimal Quantity { get; set; } // 数量(基础单位)

        public decimal SecondaryQuantity { get; set; } // 数量(二级单位)

        public decimal Weight { get; set; } // 重量(kg)

        public bool IsListed { get; set; } // 挂单状态

        public string Status { get; set; } // 材料状态(良品/报废)

        public int LocationCycle { get; set; } // 位置周期

        public DateTime FirstReportTime { get; set; } // 初次上报时间

        public DateTime LastReportTime { get; set; } // 最近上报时间

        public int MerchantId { get; set; } // 所属商家ID

        [StringLength(200)]
        public string Location { get; set; } // 位置信息

        public DateTime CreateTime { get; set; }
        public string OrderType { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? PaymentTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public decimal? ReferencePrice { get; set; }

        public decimal TotalQuantity { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal OwnQuantity { get; set; }
        public decimal OwnWeight { get; set; }
        public int ClientCount { get; set; }
        public decimal ClientQuantity { get; set; }
        public decimal ClientWeight { get; set; }
        public decimal OnSiteQuantity { get; set; }
        public decimal OnSiteWeight { get; set; }
        public decimal OwnOnSiteQuantity { get; set; }
        public decimal OwnOnSiteWeight { get; set; }
        public decimal ClientOnSiteQuantity { get; set; }
        public decimal ClientOnSiteWeight { get; set; }
        public string MainImage { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(MaterialImage.MaterialId))]
        public List<MaterialImage> Images { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(MaterialDetail.MaterialId))]
        public List<MaterialDetail> MaterialDetails { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(MaterialHistory.MaterialId))]
        public List<MaterialHistory> MaterialHistories { get; set; }

        public string LocationStatus { get; set; }
        public string SubCategory { get; set; } // 保留旧字段

        [SugarColumn(ColumnName = "sub_category_id", IsNullable = true)]
        public int? SubCategoryId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(SubCategoryId))]
        public SubCategory SubCategoryEntity { get; set; }

        public string RentalStatus { get; set; }
    }
}