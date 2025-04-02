using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IProjectService
    {
        Task<Project> GetProject(int id);

        Task<PaginatedList<Project>> GetProjects(ProjectQuery query);

        Task<int> CreateProject(ProjectCreateDto dto);

        Task<bool> UpdateProject(ProjectUpdateDto dto);

        Task<bool> DeleteProject(int id);

        // 工程操作记录
        Task<bool> AddEntryRecord(int projectId, ProjectOperationDto dto);

        Task<bool> AddWithdrawalRecord(int projectId, ProjectOperationDto dto);

        Task<bool> AddInventoryRecord(int projectId, ProjectOperationDto dto);

        Task<bool> AddSuspensionRecord(int projectId, ProjectOperationDto dto);

        // 工程量记录
        Task<bool> UpdateProgressQuantity(int projectId, string quantity);

        // 财务记录
        Task<bool> UpdatePaymentStatus(int projectId, PaymentUpdateDto dto);
    }

    public class ProjectQuery
    {
        public string Keyword { get; set; }
        public string Status { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ProjectCreateDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string Client { get; set; }
        public string ContactPerson { get; set; }
        public string EstimatedQuantity { get; set; }
    }

    public class ProjectUpdateDto
    {
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string ContactPerson { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }
    }

    public class ProjectOperationDto
    {
        public DateTime OperationTime { get; set; }
        public string Operator { get; set; }
        public string Details { get; set; }
    }

    public class PaymentUpdateDto
    {
        public decimal PaidAmount { get; set; }
        public string PaymentNote { get; set; }
    }
}