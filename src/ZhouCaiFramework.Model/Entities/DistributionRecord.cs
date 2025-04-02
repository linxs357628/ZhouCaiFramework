using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    public class DistributionRecord
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(IsNullable = false)]
        public int InquiryId { get; set; }

        [SugarColumn(IsNullable = false)]
        public int MerchantId { get; set; }

        [SugarColumn(IsNullable = false, Length = 100)]
        public string MerchantName { get; set; }

        [SugarColumn(IsNullable = false)]
        public DateTime DistributionTime { get; set; }

        [SugarColumn(Length = 500)]
        public string Remarks { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(InquiryId))]
        public virtual EcoInquiry EcoInquiry { get; set; }
    }
}