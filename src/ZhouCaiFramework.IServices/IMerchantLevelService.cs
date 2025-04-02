using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IMerchantLevelService
    {
        Task<MerchantLevel> Create(MerchantLevel level);

        Task<bool> Update(MerchantLevel level);

        Task<bool> Disable(int levelId);

        Task<bool> Delete(int levelId);

        Task<MerchantLevel> GetById(int levelId);

        Task<IEnumerable<MerchantLevel>> GetAll();

        Task<IEnumerable<MerchantLevel>> GetByEnterpriseType(string enterpriseType);
    }
}