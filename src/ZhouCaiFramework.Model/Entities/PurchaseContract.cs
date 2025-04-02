using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ²É¹ººÏÍ¬
    /// </summary>
    public class PurchaseContract
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public string ContractNumber { get; set; }

        public int EnterpriseId { get; set; }

        public int SupplierId { get; set; }

        [SugarColumn(Length = 100)]
        public string MaterialType { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime DeliveryDate { get; set; }

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

        [SugarColumn(Length = 500)]
        public string DeliveryAddress { get; set; }

        [SugarColumn(Length = 20)]
        public string TaxRate { get; set; }
    }
}