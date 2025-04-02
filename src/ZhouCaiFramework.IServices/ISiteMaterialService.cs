using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface ISiteMaterialService
    {
        Task<PaginatedList<SiteMaterialDto>> GetSiteMaterials(SiteMaterialQuery query);

        Task<PaginatedList<SiteMaterialDto>> GetProjectMaterials(ProjectMaterialQuery query);

        Task<List<MaterialHistory>> GetMaterialHistory(string materialCode);

        Task<bool> UpdateMaterial(int id, SiteMaterialUpdateDto dto);

        Task<bool> DeleteMaterial(int id);
    }

    public class SiteMaterialDto
    {
        public string MaterialCode { get; set; }
        public string Category { get; set; }
        public string MaterialName { get; set; }
        public string Specification { get; set; }
        public string Owner { get; set; }
        public bool IsPending { get; set; }
        public bool IsMortgaged { get; set; }
        public DateTime CreateTime { get; set; }
        public string LatestResult { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
        public string CurrentLocation { get; set; }
        public string LocationName { get; set; }
        public DateTime LastReportTime { get; set; }
        public int LocationPeriod { get; set; }
        public string ProjectName { get; set; }
        public string StorageCode { get; set; }
        public int LockPeriod { get; set; }
        public DateTime? ArrivalTime { get; set; }
    }

    public class SiteMaterialQuery
    {
        public string Keyword { get; set; }
        public List<string> Categories { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string> Statuses { get; set; }
        public int? MinDays { get; set; }
        public int? MaxDays { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class SiteMaterialUpdateDto
    {
        public string MaterialName { get; set; }
        public string Specification { get; set; }
        public decimal? Weight { get; set; }
        public string Status { get; set; }
    }

    public class ProjectMaterialQuery : SiteMaterialQuery
    {
        public int ProjectId { get; set; }
        public int? SharedStorageId { get; set; }
        public bool ShowAllSources { get; set; } = false;
    }
}