using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ×âÁÞºÏÍ¬
    /// </summary>
    public class RentalContract
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public string ContractNumber { get; set; }

        public int EnterpriseId { get; set; }

        public int SupplierId { get; set; }

        [SugarColumn(Length = 100)]
        public string MaterialType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal TotalAmount { get; set; }

        [SugarColumn(Length = 20)]
        public string PaymentMethod { get; set; }

        [SugarColumn(Length = 20)]
        public string Status { get; set; }

        [SugarColumn(Length = 500)]
        public string Terms { get; set; }

        [SugarColumn(Length = 100)]
        public string Signer { get; set; }

        public DateTime SignDate { get; set; }

        [SugarColumn(Length = 1000)]
        public string AttachmentUrls { get; set; }

        [SugarColumn(Length = 50)]
        public string Approver { get; set; }

        public DateTime? ApproveDate { get; set; }
    }
}