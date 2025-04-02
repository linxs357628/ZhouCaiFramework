using SqlSugar;
using System;

namespace ZhouCaiFramework.Model.Entities
{
    public class MaterialLock
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(IsNullable = false, Length = 50)]
        public string DocumentNo { get; set; } // 出库单号 GXC02-G-241119-01

        [SugarColumn(IsNullable = false)]
        public int MaterialId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(MaterialId))]
        public virtual Material Material { get; set; }

        [SugarColumn(IsNullable = false)]
        public int ProjectId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(ProjectId))]
        public virtual Project Project { get; set; }

        [SugarColumn(IsNullable = false, Length = 20)]
        public string Type { get; set; } // 出入库类型

        [SugarColumn(Length = 200)]
        public string Reason { get; set; } // 出入库原因

        public int LockDays { get; set; } // 锁库周期(天)

        public decimal Weight { get; set; } // 重量(吨)

        public decimal Quantity { get; set; } // 出库数量

        [SugarColumn(IsNullable = false)]
        public DateTime CreateTime { get; set; } // 创建时间

        [SugarColumn(IsNullable = false)]
        public DateTime PlanTime { get; set; } // (预)出入库时间

        [SugarColumn(Length = 100)]
        public string Renter { get; set; } // 租赁方

        [SugarColumn(IsNullable = false)]
        public int WarehouseId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(WarehouseId))]
        public virtual Warehouse Warehouse { get; set; } // 存放仓库

        [SugarColumn(IsNullable = false, Length = 20)]
        public string Status { get; set; } // 当前状态:在途中/在仓库/在工地

        [SugarColumn(IsNullable = false)]
        public int OperatorId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(OperatorId))]
        public virtual Employee Operator { get; set; } // 操作人

        public bool IsScanned { get; set; } // 是否已扫码
    }
}