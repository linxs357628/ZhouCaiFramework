using System;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialHistoryDto
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        public DateTime EventTime { get; set; }
        public string EventType { get; set; }
        public string EventTypeName { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal QuantityChange { get; set; }
        public decimal WeightChange { get; set; }
        public string OperatorName { get; set; }
        public string OperatorPhone { get; set; }
        public string StatusBefore { get; set; }
        public string StatusAfter { get; set; }
        public string ProjectName { get; set; }
        public string WarehouseName { get; set; }
    }

    //public class MaterialHistoryQueryDto
    //{
    //    public int MaterialId { get; set; }
    //    public string EventType { get; set; }
    //    public DateTime? StartTime { get; set; }
    //    public DateTime? EndTime { get; set; }
    //}
}