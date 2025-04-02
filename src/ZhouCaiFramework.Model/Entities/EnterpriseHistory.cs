using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 企业历史
    /// </summary>
    public class EnterpriseHistory
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int EnterpriseId { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string EnterpriseName { get; set; }

        public DateTime JoinTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? LeaveTime { get; set; }
    }
}