using System;
using System.Collections.Generic;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialOutboundDetailDto
    {
        // 基础信息
        public DateTime CreateTime { get; set; }
        public string DocumentNo { get; set; }
        public DateTime PlanOutboundTime { get; set; }
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public string Reason { get; set; }
        public decimal TotalWeight { get; set; }
        public string Owner { get; set; }
        public string KeeperName { get; set; }
        public string KeeperPhone { get; set; }
        public string RelatedOrderNo { get; set; }
        public string ShippingPlace { get; set; }
        public string ReceivingPlace { get; set; }

        // 出库内容
        public List<MaterialOutboundItemDto> Items { get; set; } = new List<MaterialOutboundItemDto>();
    }

    public class MaterialOutboundItemDto
    {
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string Specification { get; set; }
        public decimal Quantity { get; set; }
        public int PackageCount { get; set; }
        public decimal Weight { get; set; }
        public string Owner { get; set; }
    }
}
