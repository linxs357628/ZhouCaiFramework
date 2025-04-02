using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class ManualPaymentService : IManualPaymentService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<ManualPaymentService> _logger;

        public ManualPaymentService(ISqlSugarClient db, ILogger<ManualPaymentService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<ManualPaymentRecord> CreateAsync(ManualPaymentRecord record)
        {
            try
            {
                return await _db.Insertable(record).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建人工记账记录失败");
                throw;
            }
        }

        public async Task<ManualPaymentRecord> UpdateAsync(ManualPaymentRecord record)
        {
            try
            {
                await _db.Updateable(record).ExecuteCommandAsync();
                return await GetByIdAsync(record.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新人工记账记录失败");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _db.Deleteable<ManualPaymentRecord>()
                    .Where(r => r.Id == id)
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除人工记账记录失败");
                throw;
            }
        }

        public async Task<ManualPaymentRecord> GetByIdAsync(int id)
        {
            return await _db.Queryable<ManualPaymentRecord>()
                .FirstAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<ManualPaymentRecord>> GetByProjectAsync(int projectId)
        {
            return await _db.Queryable<ManualPaymentRecord>()
                .Where(r => r.ProjectId == projectId)
                .ToListAsync();
        }
    }
}