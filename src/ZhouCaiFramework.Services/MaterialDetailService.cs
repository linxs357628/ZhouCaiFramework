using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class MaterialDetailService : IMaterialDetailService
    {
        private readonly ISqlSugarClient _db;

        public MaterialDetailService(ISqlSugarClient db)
        {
            _db = db;
        }

        public async Task<PaginatedList<MaterialDetail>> GetDetails(
            int materialId,
            string keyword,
            List<string> categories,
            DateTime? startDate,
            DateTime? endDate,
            List<string> statuses,
            int? minDays,
            int? maxDays,
            int page,
            int pageSize)
        {
            var query = _db.Queryable<MaterialDetail>()
                .Where(m => m.MaterialId == materialId)
                .WhereIF(!string.IsNullOrEmpty(keyword), m =>
                    m.MaterialCode.Contains(keyword) ||
                    m.Owner.Contains(keyword) ||
                    m.CurrentLocation.Contains(keyword))
                .WhereIF(categories != null && categories.Any(), m =>
                    categories.Contains(m.Category))
                .WhereIF(startDate.HasValue, m =>
                    m.LastReportTime >= startDate.Value)
                .WhereIF(endDate.HasValue, m =>
                    m.LastReportTime <= endDate.Value)
                .WhereIF(statuses != null && statuses.Any(), m =>
                    statuses.Contains(m.Status))
                .WhereIF(minDays.HasValue, m =>
                    m.LocationPeriod >= minDays.Value)
                .WhereIF(maxDays.HasValue, m =>
                    m.LocationPeriod <= maxDays.Value);

            var totalCount = await query.CountAsync();
            var items = await query.ToPageListAsync(page, pageSize);

            return new PaginatedList<MaterialDetail>(items, totalCount, page, pageSize);
        }

        public async Task<List<MaterialHistory>> GetMaterialHistory(string materialCode)
        {
            return await _db.Queryable<MaterialHistory>()
                .Where(h => h.MaterialCode == materialCode)
                .OrderByDescending(h => h.EventTime)
                .ToListAsync();
        }
    }
}