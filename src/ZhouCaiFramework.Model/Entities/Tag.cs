using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Tag
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50, IsNullable = false)]
        public string Name { get; set; }

        [SugarColumn(Length = 20, IsNullable = false)]
        public string Color { get; set; } // 存储16进制颜色码如#FF0000

        [SugarColumn(DefaultValue = "1")]
        public int Status { get; set; } // 1-启用 0-禁用

        [SugarColumn(DefaultValue = "0")]
        public bool IsHidden { get; set; } // 是否隐藏

        public string EnterpriseType { get; set; }
    }
}