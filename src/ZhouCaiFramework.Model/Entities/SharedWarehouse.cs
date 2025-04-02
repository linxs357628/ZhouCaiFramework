using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 共享仓库
    /// </summary>
    public class SharedWarehouse
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Name { get; set; } // 仓库名称

        [SugarColumn(Length = 200)]
        public string Location { get; set; } // 仓库位置

        [SugarColumn(Length = 50)]
        public string ContactPerson { get; set; } // 联系人

        [SugarColumn(Length = 20)]
        public string ContactPhone { get; set; } // 联系电话

        public decimal TotalArea { get; set; } // 总面积(m²)
        public decimal UsedArea { get; set; } // 已用面积(m²)
        public int TotalCapacity { get; set; } // 总容量(单位)
        public int UsedCapacity { get; set; } // 已用容量(单位)

        [SugarColumn(Length = 20)]
        public string Status { get; set; } = "正常"; // 状态:正常/停用/维护

        [SugarColumn(Length = 500)]
        public string Description { get; set; } // 仓库描述

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Creator { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Updater { get; set; }

        // 导航属性
        [Navigate(NavigateType.OneToMany, nameof(SharedWarehouseMaterial.WarehouseId))]
        public List<SharedWarehouseMaterial> Materials { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(SharedWarehouseRecord.WarehouseId))]
        public List<SharedWarehouseRecord> Records { get; set; }

        public int EnterpriseId { get; set; }
        public string Address { get; set; }
        public string MainStorage { get; set; }
        public decimal Area { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public bool IsShared { get; set; }
        public string Type { get; set; }
    }

    /// <summary>
    /// 共享仓库材料
    /// </summary>
    public class SharedWarehouseMaterial
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int WarehouseId { get; set; } // 仓库ID
        public int MaterialId { get; set; } // 材料ID
        public string MaterialName { get; set; } // 材料名称
        public string MaterialType { get; set; } // 材料类型
        public string Specification { get; set; } // 规格
        public string Unit { get; set; } // 单位
        public int Quantity { get; set; } // 数量
        public decimal AreaOccupied { get; set; } // 占用面积(m²)

        [SugarColumn(Length = 20)]
        public string Status { get; set; } = "在库"; // 状态:在库/出库/调拨中

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// 共享仓库记录
    /// </summary>
    public class SharedWarehouseRecord
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int WarehouseId { get; set; } // 仓库ID
        public int MaterialId { get; set; } // 材料ID
        public string OperationType { get; set; } // 操作类型:入库/出库/调拨
        public int Quantity { get; set; } // 操作数量
        public string Operator { get; set; } // 操作人
        public DateTime OperationTime { get; set; } = DateTime.Now;
        public string TargetWarehouse { get; set; } // 目标仓库(调拨时使用)
        public string Remark { get; set; } // 备注
    }
}