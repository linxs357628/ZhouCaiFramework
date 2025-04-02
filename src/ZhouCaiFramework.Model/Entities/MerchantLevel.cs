using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 商户等级
    /// </summary>
    public class MerchantLevel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public string EnterpriseType { get; set; }

        [SugarColumn(Length = 50)]
        public string Level { get; set; }

        [SugarColumn]
        public int MerchantCount { get; set; }

        [SugarColumn(DefaultValue = "1")]
        public int Status { get; set; } // 1-启用 0-禁用

        [SugarColumn(ColumnDataType = "text")]
        public string Permissions { get; set; } // JSON格式存储权限内容
    }
}