using System;
using ZhouCaiFramework.Common;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialHistoryQueryDto : PaginationQuery
    {
        public int? MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public string EventType { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? WarehouseId { get; set; }
        public int? ProjectId { get; set; }
        public string OperatorName { get; set; }
    }
}
