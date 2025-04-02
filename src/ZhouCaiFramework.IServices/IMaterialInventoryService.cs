using ZhouCaiFramework.Common;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialInventoryService
    {
        Task<PaginatedList<MaterialInventory>> GetInventory(
            string keyword,
            List<string> orderTypes,
            DateTime? startDate,
            DateTime? endDate,
            string paymentStatus,
            int page,
            int pageSize);
    }

    public class MaterialInventory
    {
        public string Category { get; set; }
        public string MaterialName { get; set; }
        public decimal? ReferencePrice { get; set; }
        public string Specification { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal OwnQuantity { get; set; }
        public decimal OwnWeight { get; set; }
        public int ClientCount { get; set; }
        public decimal ClientQuantity { get; set; }
        public decimal ClientWeight { get; set; }
        public decimal OnSiteQuantity { get; set; }
        public decimal OnSiteWeight { get; set; }
        public decimal OwnOnSiteQuantity { get; set; }
        public decimal OwnOnSiteWeight { get; set; }
        public decimal ClientOnSiteQuantity { get; set; }
        public decimal ClientOnSiteWeight { get; set; }
    }
}