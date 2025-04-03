using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public class Project
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public string Number { get; set; }

        [SugarColumn(Length = 100)]
        public string Name { get; set; }

        [SugarColumn(Length = 200)]
        public string Location { get; set; }

        [SugarColumn(Length = 100)]
        public string Client { get; set; }

        [SugarColumn(Length = 50)]
        public string ContactPerson { get; set; }

        [SugarColumn(Length = 20)]
        public string Status { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [SugarColumn(Length = 20)]
        public string EstimatedQuantity { get; set; }

        [SugarColumn(Length = 20)]
        public string ProgressQuantity { get; set; }

        [SugarColumn(Length = 20)]
        public string QuantityDifference { get; set; }

        [SugarColumn(Length = 20)]
        public string UndeliveredQuantity { get; set; }

        [SugarColumn(Length = 20)]
        public string OnsiteQuantity { get; set; }

        [SugarColumn(Length = 20)]
        public string WithdrawnQuantity { get; set; }

        [SugarColumn(Length = 20)]
        public string PaidAmount { get; set; }

        [SugarColumn(Length = 20)]
        public string UnpaidAmount { get; set; }

        public DateTime? LastInventoryTime { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<ProjectOperation> Operations { get; set; }
    }

    /// <summary>
    /// 项目操作信息
    /// </summary>
    public class ProjectOperation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string OperationType { get; set; } // 进场/撤场/盘点/报停
        public DateTime OperationTime { get; set; }
        public string Operator { get; set; }
        public string Details { get; set; }
    }
}