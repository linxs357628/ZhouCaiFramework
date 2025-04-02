using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ISqlSugarClient _db;

        public ProjectService(ISqlSugarClient db)
        {
            _db = db;
        }

        public async Task<Project> GetProject(int id)
        {
            return await _db.Queryable<Project>()
                .Where(p => p.Id == id)
                .FirstAsync();
        }

        public async Task<PaginatedList<Project>> GetProjects(ProjectQuery query)
        {
            var q = _db.Queryable<Project>()
                .WhereIF(!string.IsNullOrEmpty(query.Keyword), p =>
                    p.ProjectName.Contains(query.Keyword) ||
                    p.ProjectNumber.Contains(query.Keyword) ||
                    p.Client.Contains(query.Keyword))
                .WhereIF(!string.IsNullOrEmpty(query.Status), p =>
                    p.Status == query.Status);

            var count = await q.CountAsync();
            var items = await q.ToPageListAsync(query.Page, query.PageSize);

            return new PaginatedList<Project>(items, count, query.Page, query.PageSize);
        }

        public async Task<int> CreateProject(ProjectCreateDto dto)
        {
            var project = new Project
            {
                ProjectNumber = dto.ProjectNumber,
                ProjectName = dto.ProjectName,
                Location = dto.Location,
                Client = dto.Client,
                ContactPerson = dto.ContactPerson,
                EstimatedQuantity = dto.EstimatedQuantity,
                Status = "未开始"
            };

            return await _db.Insertable(project).ExecuteReturnIdentityAsync();
        }

        public async Task<bool> UpdateProject(ProjectUpdateDto dto)
        {
            return await _db.Updateable<Project>()
                .SetColumns(p => new Project
                {
                    ProjectName = dto.ProjectName,
                    Location = dto.Location,
                    ContactPerson = dto.ContactPerson,
                    Status = dto.Status
                })
                .Where(p => p.Id == dto.Id)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteProject(int id)
        {
            return await _db.Deleteable<Project>()
                .Where(p => p.Id == id)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> AddEntryRecord(int projectId, ProjectOperationDto dto)
        {
            var record = new ProjectOperation
            {
                ProjectId = projectId,
                OperationType = "进场",
                OperationTime = dto.OperationTime,
                Operator = dto.Operator,
                Details = dto.Details
            };

            return await _db.Insertable(record).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> AddWithdrawalRecord(int projectId, ProjectOperationDto dto)
        {
            var record = new ProjectOperation
            {
                ProjectId = projectId,
                OperationType = "撤场",
                OperationTime = dto.OperationTime,
                Operator = dto.Operator,
                Details = dto.Details
            };

            return await _db.Insertable(record).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> AddInventoryRecord(int projectId, ProjectOperationDto dto)
        {
            var record = new ProjectOperation
            {
                ProjectId = projectId,
                OperationType = "盘点",
                OperationTime = dto.OperationTime,
                Operator = dto.Operator,
                Details = dto.Details
            };

            return await _db.Insertable(record).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> AddSuspensionRecord(int projectId, ProjectOperationDto dto)
        {
            var record = new ProjectOperation
            {
                ProjectId = projectId,
                OperationType = "报停",
                OperationTime = dto.OperationTime,
                Operator = dto.Operator,
                Details = dto.Details
            };

            return await _db.Insertable(record).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> UpdateProgressQuantity(int projectId, string quantity)
        {
            return await _db.Updateable<Project>()
                .SetColumns(p => p.ProgressQuantity == quantity)
                .Where(p => p.Id == projectId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> UpdatePaymentStatus(int projectId, PaymentUpdateDto dto)
        {
            return await _db.Updateable<Project>()
                .SetColumns(p => new Project
                {
                    PaidAmount = dto.PaidAmount.ToString(),
                    UnpaidAmount = (decimal.Parse(p.UnpaidAmount) - dto.PaidAmount).ToString()
                })
                .Where(p => p.Id == projectId)
                .ExecuteCommandHasChangeAsync();
        }
    }
}