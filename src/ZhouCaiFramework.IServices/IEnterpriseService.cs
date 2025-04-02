using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IEnterpriseService
    {
        Task<Enterprise> Create(Enterprise enterprise);

        Task<bool> Update(Enterprise enterprise);

        Task<bool> Disable(int enterpriseId);

        Task<bool> Delete(int enterpriseId);

        Task<Enterprise> GetById(int enterpriseId);

        Task<IEnumerable<Enterprise>> GetAll();

        Task<IEnumerable<Enterprise>> GetByType(string enterpriseType);

        // 共享仓管理
        Task<SharedWarehouse> AddWarehouse(SharedWarehouse warehouse);

        Task<bool> UpdateWarehouse(SharedWarehouse warehouse);

        Task<bool> RemoveWarehouse(int warehouseId);

        // 验证方法
        Task<bool> ValidateEnterpriseName(string name);

        Task<bool> ValidateWarehouseName(int enterpriseId, string name);
    }
}