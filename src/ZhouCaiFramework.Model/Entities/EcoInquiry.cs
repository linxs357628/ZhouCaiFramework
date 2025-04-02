using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    public class EcoInquiry
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(IsNullable = false)]
        public DateTime InquiryTime { get; set; }

        [SugarColumn(IsNullable = false)]
        public int InquirerId { get; set; }

        [SugarColumn(IsNullable = false, Length = 100)]
        public string InquirerName { get; set; }

        [SugarColumn(IsNullable = false, Length = 50)]
        public string EntryPoint { get; set; }

        [SugarColumn(IsNullable = false, Length = 20)]
        public string InquiryType { get; set; } // 租赁/购买

        [SugarColumn(Length = 500)]
        public string InquiryItems { get; set; } // JSON格式存储商品信息

        public int ItemCount { get; set; }

        [SugarColumn(Length = 20)]
        public string Unit { get; set; }

        [SugarColumn(IsNullable = false, Length = 50)]
        public string ContactName { get; set; }

        [SugarColumn(IsNullable = false, Length = 20)]
        public string ContactPhone { get; set; }

        [SugarColumn(Length = 500)]
        public string DeliveryAddress { get; set; } // 省市区详细地址

        public int DistributionCount { get; set; }

        [SugarColumn(Length = 200)]
        public string Tags { get; set; }

        [SugarColumn(Length = 500, IsNullable = false)]
        public string Remarks { get; set; }
    }
}