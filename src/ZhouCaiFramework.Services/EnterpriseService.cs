using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<EnterpriseService> _logger;

        public EnterpriseService(ISqlSugarClient db, ILogger<EnterpriseService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Enterprise> Create(Enterprise enterprise)
        {
            try
            {
                // 验证企业名称
                if (!await ValidateEnterpriseName(enterprise.Name))
                {
                    throw new Exception("企业名称已存在或不符合要求");
                }

                // 设置默认值
                enterprise.Status = 0; // 正常状态
                enterprise.CreateTime = DateTime.Now;

                return await _db.Insertable(enterprise).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建企业失败");
                throw;
            }
        }

        public async Task<bool> Update(Enterprise enterprise)
        {
            return await _db.Updateable(enterprise)
                .IgnoreColumns(x => new { x.CreateTime, x.Status })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Disable(int enterpriseId)
        {
            return await _db.Updateable<Enterprise>()
                .SetColumns(x => x.Status == 1)
                .Where(x => x.Id == enterpriseId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Delete(int enterpriseId)
        {
            return await _db.Deleteable<Enterprise>()
                .Where(x => x.Id == enterpriseId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<Enterprise> GetById(int enterpriseId)
        {
            var enterprise = await _db.Queryable<Enterprise>()
                .Where(x => x.Id == enterpriseId)
                .FirstAsync();

            if (enterprise != null)
            {
                enterprise.Warehouses = await _db.Queryable<SharedWarehouse>()
                    .Where(x => x.EnterpriseId == enterpriseId)
                    .ToListAsync();
            }

            return enterprise;
        }

        public async Task<IEnumerable<Enterprise>> GetAll()
        {
            return await _db.Queryable<Enterprise>()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enterprise>> GetByType(string enterpriseType)
        {
            return await _db.Queryable<Enterprise>()
                .Where(x => x.EnterpriseType == enterpriseType)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<SharedWarehouse> AddWarehouse(SharedWarehouse warehouse)
        {
            // 验证仓库名称
            if (!await ValidateWarehouseName(warehouse.EnterpriseId, warehouse.Name))
            {
                throw new Exception("仓库名称已存在");
            }

            warehouse.Status = "正常"; // 正常状态
            return await _db.Insertable(warehouse).ExecuteReturnEntityAsync();
        }

        public async Task<bool> UpdateWarehouse(SharedWarehouse warehouse)
        {
            return await _db.Updateable(warehouse)
                .IgnoreColumns(x => new { x.EnterpriseId, x.Status })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> RemoveWarehouse(int warehouseId)
        {
            return await _db.Deleteable<SharedWarehouse>()
                .Where(x => x.Id == warehouseId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> ValidateEnterpriseName(string name)
        {
            // 检查是否为共享仓企业名称
            var isSharedStorage = await _db.Queryable<Enterprise>()
                .AnyAsync(x => x.Name == name && x.EnterpriseType == "共享仓商家");

            return !isSharedStorage;
        }

        public async Task<bool> ValidateWarehouseName(int enterpriseId, string name)
        {
            return !await _db.Queryable<SharedWarehouse>()
                .AnyAsync(x => x.EnterpriseId == enterpriseId && x.Name == name);
        }
    }
}