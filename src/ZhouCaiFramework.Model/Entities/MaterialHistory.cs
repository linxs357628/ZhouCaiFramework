using SqlSugar;
using System;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 材料变更历史记录
    /// </summary>
    public class MaterialHistory
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(MaterialId))]
        public virtual Material Material { get; set; }

        public DateTime EventTime { get; set; }

        [SugarColumn(IsNullable = false, Length = 20)]
        public string EventType { get; set; } // 创建/出库/入库/盘点/验收/交易

        [SugarColumn(IsNullable = true)]
        public int? RelatedDocumentId { get; set; } // 关联单据ID

        [SugarColumn(Length = 50)]
        public string DocumentNo { get; set; } // 关联单据编号

        [SugarColumn(Length = 500)]
        public string Description { get; set; } // 变更描述

        [SugarColumn(Length = 100)]
        public string Location { get; set; } // 位置信息

        public decimal QuantityChange { get; set; } // 数量变化
        public decimal WeightChange { get; set; } // 重量变化

        public int OperatorId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(OperatorId))]
        public virtual Employee Operator { get; set; } // 操作人

        [SugarColumn(Length = 50)]
        public string MaterialCode { get; set; } // 材料编码

        [SugarColumn(Length = 20)]
        public string StatusBefore { get; set; } // 变更前状态

        [SugarColumn(Length = 20)]
        public string StatusAfter { get; set; } // 变更后状态

        [SugarColumn(Length = 50)]
        public string ProjectName { get; set; } // 关联项目

        [SugarColumn(Length = 50)]
        public string WarehouseName { get; set; } // 仓库名称

        public int ProjectId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(ProjectId))]
        public virtual Project Project { get; set; }

        public int WarehouseId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(WarehouseId))]
        public virtual Warehouse Warehouse { get; set; }
    }
}