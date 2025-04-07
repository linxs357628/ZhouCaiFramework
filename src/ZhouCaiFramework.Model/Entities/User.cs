using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    public enum UserType
    {
        Normal = 0,
        Platform = 1
    }

    /// <summary>
    /// �û�
    /// </summary>
    public class User
    {
        [SugarColumn]
        public UserType Type { get; set; } = UserType.Normal;

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public string Username { get; set; }

        [SugarColumn(Length = 50)]
        public string Nickname { get; set; }

        [SugarColumn(Length = 50)]
        public string RealName { get; set; }

        [SugarColumn(Length = 20)]
        public string Phone { get; set; }

        [SugarColumn(Length = 200)]
        public string PasswordHash { get; set; }

        [SugarColumn(Length = 100)]
        public string WechatOpenId { get; set; }

        public bool IsMainAccount { get; set; }

        [SugarColumn(Length = 500)]
        public string EnterpriseIds { get; set; }

        [SugarColumn(Length = 500)]
        public string Positions { get; set; }

        [SugarColumn(Length = 500)]
        public string Roles { get; set; }

        public DateTime RegisterTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? LastLoginTime { get; set; }

        [SugarColumn(Length = 50)]
        public string LastLoginPlatform { get; set; }

        [SugarColumn(Length = 20)]
        public string Status { get; set; }

        public int EnterpriseId { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}