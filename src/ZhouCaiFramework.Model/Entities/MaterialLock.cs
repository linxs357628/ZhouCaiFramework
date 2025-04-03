using SqlSugar;
using System;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 材料锁库记录实体
    /// 记录材料的出入库锁定信息
    /// </summary>
    public class MaterialLock
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public virtual string DocumentNo { get; set; } // 出库单号 GXC02-G-241119-01

        public virtual int MaterialId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(MaterialId))]
        public virtual Material Material { get; set; }

        public virtual int ProjectId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(ProjectId))]
        public virtual Project Project { get; set; }

        [SugarColumn(Length = 20)]
        public virtual string Type { get; set; } // 出入库类型

        [SugarColumn(Length = 200)]
        public string Reason { get; set; } // 出入库原因

        public int LockDays { get; set; } // 锁库周期(天)

        public decimal Weight { get; set; } // 重量(吨)

        public decimal Quantity { get; set; } // 出库数量

        public DateTime CreateTime { get; set; } // 创建时间

        public DateTime PlanTime { get; set; } // (预)出入库时间

        [SugarColumn(Length = 100)]
        public string Renter { get; set; } // 租赁方

        public virtual int WarehouseId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(WarehouseId))]
        public virtual Warehouse Warehouse { get; set; } // 存放仓库

        [SugarColumn(Length = 20)]
        public virtual string Status { get; set; } // 当前状态:在途中/在仓库/在工地

        public virtual int OperatorId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(OperatorId))]
        public virtual Employee Operator { get; set; } // 操作人

        public bool IsScanned { get; set; } // 是否已扫码
        public string Location { get; set; }
        public string ProjectName { get; set; }
    }
}