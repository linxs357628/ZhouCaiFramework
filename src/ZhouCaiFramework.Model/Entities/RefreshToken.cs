using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// Ë¢ÐÂToken
    /// </summary>
    public class RefreshToken
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Token { get; set; }

        public int UserId { get; set; }

        public DateTime Expires { get; set; }

        [SugarColumn(Length = 50)]
        public string CreatedByIp { get; set; }

        public DateTime Created { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? Revoked { get; set; }

        [SugarColumn(Length = 50, IsNullable = true)]
        public string RevokedByIp { get; set; }

        [SugarColumn(Length = 500, IsNullable = true)]
        public string ReplacedByToken { get; set; }

        [SugarColumn(Length = 100, IsNullable = true)]
        public string ReasonRevoked { get; set; }
    }
}