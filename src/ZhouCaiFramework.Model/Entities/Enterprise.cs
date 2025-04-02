using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ∆Û“µ
    /// </summary>
    public class Enterprise
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Name { get; set; }

        [SugarColumn(Length = 50)]
        public string Code { get; set; }

        [SugarColumn(Length = 20)]
        public string Type { get; set; }

        [SugarColumn(Length = 50)]
        public string LegalPerson { get; set; }

        [SugarColumn(Length = 20)]
        public string ContactPhone { get; set; }

        [SugarColumn(Length = 100)]
        public string Address { get; set; }

        [SugarColumn(Length = 50)]
        public string BusinessLicense { get; set; }

        public int Status { get; set; }

        public DateTime RegisterTime { get; set; }
        public DateTime? ApproveTime { get; set; }

        [SugarColumn(Length = 500)]
        public string Description { get; set; }

        [SugarColumn(Length = 50)]
        public string Region { get; set; }

        public decimal CreditScore { get; set; }

        [SugarColumn(Length = 50)]
        public string Industry { get; set; }

        public DateTime CreateTime { get; set; }

        public List<SharedWarehouse> Warehouses { get; set; }
        public string EnterpriseType { get; set; }
        public bool IsSharedStorage { get; set; }
        public string ShortName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Level { get; set; }
        public int? ParentEnterpriseId { get; set; }
        public string LegalPhone { get; set; }
        public string EnterprisePrefix { get; set; }
        public int SalesmanId { get; set; }
        public int MainAccountId { get; set; }
        public string Grade { get; set; }

        [SugarColumn(IsNullable = true)]
        public string Tags { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? UpdateTime { get; set; }
    }
}