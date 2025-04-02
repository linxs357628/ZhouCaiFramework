namespace ZhouCaiFramework.Model.Dtos
{
    public static class MaterialEventTypes
    {
        public const string Create = "创建";
        public const string Outbound = "出库";
        public const string Inbound = "入库";
        public const string Inventory = "盘点";
        public const string SiteIn = "进场验收";
        public const string SiteOut = "撤场验收";
        public const string Listing = "挂单交易";
    }
}