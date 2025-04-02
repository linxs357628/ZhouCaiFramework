using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class SiteMaterialService : ISiteMaterialService
    {
        private readonly ISqlSugarClient _db;

        public SiteMaterialService(ISqlSugarClient db)
        {
            _db = db;
        }

        public async Task<PaginatedList<SiteMaterialDto>> GetSiteMaterials(SiteMaterialQuery query)
        {
            var q = _db.Queryable<MaterialDetail>()
                .WhereIF(!string.IsNullOrEmpty(query.Keyword), m =>
                    m.MaterialCode.Contains(query.Keyword) ||
                    m.Owner.Contains(query.Keyword) ||
                    m.CurrentLocation.Contains(query.Keyword))
                .WhereIF(query.Categories != null && query.Categories.Any(), m =>
                    query.Categories.Contains(m.Category))
                .WhereIF(query.Statuses != null && query.Statuses.Any(), m =>
                    query.Statuses.Contains(m.Status))
                .WhereIF(query.MinDays.HasValue, m =>
                    m.LocationPeriod >= query.MinDays.Value)
                .WhereIF(query.MaxDays.HasValue, m =>
                    m.LocationPeriod <= query.MaxDays.Value)
                .WhereIF(query.StartDate.HasValue, m =>
                    m.LastReportTime >= query.StartDate.Value)
                .WhereIF(query.EndDate.HasValue, m =>
                    m.LastReportTime <= query.EndDate.Value);

            var count = await q.CountAsync();
            var items = await q.ToPageListAsync(query.Page, query.PageSize);

            return new PaginatedList<SiteMaterialDto>(
                items.Select(x => new SiteMaterialDto
                {
                    MaterialCode = x.MaterialCode,
                    Category = x.Category,
                    MaterialName = x.MaterialName,
                    Specification = x.Specification,
                    Owner = x.Owner,
                    IsPending = x.IsPending,
                    IsMortgaged = x.IsMortgaged,
                    CreateTime = x.CreateTime,
                    LatestResult = x.LatestResult,
                    Weight = x.Weight,
                    Status = x.Status,
                    CurrentLocation = x.CurrentLocation,
                    LocationName = x.LocationName,
                    LastReportTime = x.LastReportTime,
                    LocationPeriod = x.LocationPeriod
                }).ToList(),
                count,
                query.Page,
                query.PageSize);
        }

        public async Task<List<MaterialHistory>> GetMaterialHistory(string materialCode)
        {
            return await _db.Queryable<MaterialHistory>()
                .Where(h => h.MaterialCode == materialCode)
                .OrderByDescending(h => h.EventTime)
                .ToListAsync();
        }

        public async Task<bool> UpdateMaterial(int id, SiteMaterialUpdateDto dto)
        {
            return await _db.Updateable<MaterialDetail>()
                .SetColumns(m => new MaterialDetail()
                {
                    MaterialName = dto.MaterialName,
                    Specification = dto.Specification,
                    Weight = dto.Weight ?? 0,
                    Status = dto.Status
                })
                .Where(m => m.Id == id)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            return await _db.Deleteable<MaterialDetail>()
                .Where(m => m.Id == id)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<PaginatedList<SiteMaterialDto>> GetProjectMaterials(ProjectMaterialQuery query)
        {
            var q = _db.Queryable<MaterialDetail>()
                .Where(m => m.ProjectName != null && m.ProjectName.Contains(query.ProjectId.ToString()))
                .WhereIF(!query.ShowAllSources && query.SharedStorageId.HasValue,
                    m => m.StorageCode == query.SharedStorageId.ToString())
                .WhereIF(!string.IsNullOrEmpty(query.Keyword), m =>
                    m.MaterialCode.Contains(query.Keyword) ||
                    m.Owner.Contains(query.Keyword) ||
                    m.CurrentLocation.Contains(query.Keyword))
                .WhereIF(query.Categories != null && query.Categories.Any(), m =>
                    query.Categories.Contains(m.Category))
                .WhereIF(query.Statuses != null && query.Statuses.Any(), m =>
                    query.Statuses.Contains(m.Status))
                .WhereIF(query.MinDays.HasValue, m =>
                    m.LocationPeriod >= query.MinDays.Value)
                .WhereIF(query.MaxDays.HasValue, m =>
                    m.LocationPeriod <= query.MaxDays.Value)
                .WhereIF(query.StartDate.HasValue, m =>
                    m.LastReportTime >= query.StartDate.Value)
                .WhereIF(query.EndDate.HasValue, m =>
                    m.LastReportTime <= query.EndDate.Value);

            var count = await q.CountAsync();
            var items = await q.ToPageListAsync(query.Page, query.PageSize);

            return new PaginatedList<SiteMaterialDto>(
                items.Select(x => new SiteMaterialDto
                {
                    MaterialCode = x.MaterialCode,
                    Category = x.Category,
                    MaterialName = x.MaterialName,
                    Specification = x.Specification,
                    Owner = x.Owner,
                    IsPending = x.IsPending,
                    IsMortgaged = x.IsMortgaged,
                    CreateTime = x.CreateTime,
                    LatestResult = x.LatestResult,
                    Weight = x.Weight,
                    Status = x.Status,
                    CurrentLocation = x.CurrentLocation,
                    LocationName = x.LocationName,
                    LastReportTime = x.LastReportTime,
                    LocationPeriod = x.LocationPeriod,
                    ProjectName = x.ProjectName,
                    StorageCode = x.StorageCode,
                    LockPeriod = x.LockPeriod,
                    ArrivalTime = x.ArrivalTime
                }).ToList(),
                count,
                query.Page,
                query.PageSize);
        }
    }
}