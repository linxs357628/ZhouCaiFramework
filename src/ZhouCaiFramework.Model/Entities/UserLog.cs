using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 用户日志
    /// </summary>
    public class UserLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [SugarColumn(Length = 50)]
        public string ActionType { get; set; }

        [SugarColumn(Length = 50)]
        public string ActionName { get; set; }

        [SugarColumn(Length = 100)]
        public string Description { get; set; }

        [SugarColumn(Length = 2000)]
        public string ActionData { get; set; }

        [SugarColumn(Length = 20)]
        public string Result { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDangerous { get; set; }

        [SugarColumn(Length = 50)]
        public string IpAddress { get; set; }
    }
}