using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class MaterialInventoryService : IMaterialInventoryService
    {
        private readonly ISqlSugarClient _db;

        public MaterialInventoryService(ISqlSugarClient db)
        {
            _db = db;
        }

        public async Task<PaginatedList<MaterialInventory>> GetInventory(
            string keyword,
            List<string> orderTypes,
            DateTime? startDate,
            DateTime? endDate,
            string paymentStatus,
            int page,
            int pageSize)
        {
            var query = _db.Queryable<Material>()
                .WhereIF(!string.IsNullOrEmpty(keyword), m =>
                    m.Name.Contains(keyword) ||
                    m.Specification.Contains(keyword) ||
                    m.Category.Contains(keyword))
                .WhereIF(orderTypes != null && orderTypes.Any(), m =>
                    orderTypes.Contains(m.OrderType))
                .WhereIF(startDate.HasValue, m =>
                    m.CreateTime >= startDate.Value)
                .WhereIF(endDate.HasValue, m =>
                    m.CreateTime <= endDate.Value)
                .WhereIF(!string.IsNullOrEmpty(paymentStatus), m =>
                    paymentStatus == "已支付" ? m.PaymentTime != null :
                    paymentStatus == "未支付" ? m.PaymentTime == null : true);

            var totalCount = await query.CountAsync();
            var items = await query.ToPageListAsync(page, pageSize);

            return new PaginatedList<MaterialInventory>(
                items.Select(m => new MaterialInventory
                {
                    Category = m.Category,
                    MaterialName = m.Name,
                    ReferencePrice = m.ReferencePrice,
                    Specification = m.Specification,
                    TotalQuantity = m.TotalQuantity,
                    TotalWeight = m.TotalWeight,
                    OwnQuantity = m.OwnQuantity,
                    OwnWeight = m.OwnWeight,
                    ClientCount = m.ClientCount,
                    ClientQuantity = m.ClientQuantity,
                    ClientWeight = m.ClientWeight,
                    OnSiteQuantity = m.OnSiteQuantity,
                    OnSiteWeight = m.OnSiteWeight,
                    OwnOnSiteQuantity = m.OwnOnSiteQuantity,
                    OwnOnSiteWeight = m.OwnOnSiteWeight,
                    ClientOnSiteQuantity = m.ClientOnSiteQuantity,
                    ClientOnSiteWeight = m.ClientOnSiteWeight
                }).ToList(),
                totalCount,
                page,
                pageSize);
        }
    }
}