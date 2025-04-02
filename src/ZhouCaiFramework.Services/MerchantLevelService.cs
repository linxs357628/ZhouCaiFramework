using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class MerchantLevelService : IMerchantLevelService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<MerchantLevelService> _logger;

        public MerchantLevelService(ISqlSugarClient db, ILogger<MerchantLevelService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<MerchantLevel> Create(MerchantLevel level)
        {
            try
            {
                // 检查同类型同等级是否已存在
                if (await _db.Queryable<MerchantLevel>()
                    .AnyAsync(x => x.EnterpriseType == level.EnterpriseType && x.Level == level.Level))
                {
                    throw new Exception("该企业类型下已存在相同等级");
                }

                level.MerchantCount = 0; // 初始商家数量为0
                level.Status = 1; // 默认启用

                return await _db.Insertable(level).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建商家等级失败");
                throw;
            }
        }

        public async Task<bool> Update(MerchantLevel level)
        {
            return await _db.Updateable(level)
                .IgnoreColumns(x => new { x.MerchantCount, x.Status })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Disable(int levelId)
        {
            return await _db.Updateable<MerchantLevel>()
                .SetColumns(x => x.Status == 0)
                .Where(x => x.Id == levelId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Delete(int levelId)
        {
            return await _db.Deleteable<MerchantLevel>()
                .Where(x => x.Id == levelId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<MerchantLevel> GetById(int levelId)
        {
            return await _db.Queryable<MerchantLevel>()
                .Where(x => x.Id == levelId)
                .FirstAsync();
        }

        public async Task<IEnumerable<MerchantLevel>> GetAll()
        {
            return await _db.Queryable<MerchantLevel>()
                .OrderBy(x => x.EnterpriseType)
                .OrderBy(x => x.Level)
                .ToListAsync();
        }

        public async Task<IEnumerable<MerchantLevel>> GetByEnterpriseType(string enterpriseType)
        {
            return await _db.Queryable<MerchantLevel>()
                .Where(x => x.EnterpriseType == enterpriseType)
                .OrderBy(x => x.Level)
                .ToListAsync();
        }
    }
}