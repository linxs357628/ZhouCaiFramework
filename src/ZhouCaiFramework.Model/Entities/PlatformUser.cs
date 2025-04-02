using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 平台用户
    /// </summary>
    public class PlatformUser
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public DateTime RegisterTime { get; set; } = DateTime.Now;

        [SugarColumn(Length = 50)]
        public string Nickname { get; set; }

        [SugarColumn(Length = 50)]
        public string Name { get; set; }

        [SugarColumn(Length = 20)]
        public string Phone { get; set; }

        [SugarColumn(Length = 50)]
        public string WechatOpenId { get; set; }

        public bool IsMainAccount { get; set; }

        [SugarColumn(Length = 50)]
        public string Position { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? LastLoginTime { get; set; }

        [SugarColumn(Length = 20)]
        public string LoginPort { get; set; }

        public int EnterpriseId { get; set; }

        [SugarColumn(DefaultValue = "1")]
        public int Status { get; set; } // 1-启用 0-禁用

        [SugarColumn(Length = 100)]
        public string Password { get; set; }

        [SugarColumn(Length = 50)]
        public string Salt { get; set; }
    }
}