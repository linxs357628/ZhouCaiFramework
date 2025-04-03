using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ŒÔ¡œ√˜œ∏
    /// </summary>
    public class MaterialDetail
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        [SugarColumn(Length = 50)]
        public string MaterialCode { get; set; }

        [SugarColumn(Length = 100)]
        public string Category { get; set; }

        [SugarColumn(Length = 100)]
        public string MaterialName { get; set; }

        [SugarColumn(Length = 100)]
        public string Specification { get; set; }

        [SugarColumn(Length = 50)]
        public string Owner { get; set; }

        public bool IsPending { get; set; }
        public bool IsMortgaged { get; set; }
        public DateTime CreateTime { get; set; }

        [SugarColumn(Length = 100)]
        public string LatestResult { get; set; }

        public decimal Weight { get; set; }

        [SugarColumn(Length = 20)]
        public string Status { get; set; }

        public string CurrentLocation { get; set; }
        public string LocationName { get; set; }
        public DateTime LastReportTime { get; set; }
        public int LocationPeriod { get; set; }
        public string ProjectName { get; set; }
        public string StorageCode { get; set; }
        public int LockPeriod { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? ArrivalTime { get; set; }
        public int LockId { get; set; }
        public decimal Quantity { get; set; }
        public int PackageCount { get; set; }
        public object Remark { get; set; }
    }
}