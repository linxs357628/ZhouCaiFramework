using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 物料历史记录
    /// </summary>
    public class MaterialHistory
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        public DateTime EventTime { get; set; }

        [SugarColumn(Length = 20)]
        public string EventType { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        [SugarColumn(Length = 50)]
        public string Operator { get; set; }

        public string MaterialCode { get; set; }
        public object OperationTime { get; set; }
    }
}