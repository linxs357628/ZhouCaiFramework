using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IPlatformUserService
    {
        Task<PlatformUser> Register(PlatformUser user, string password);

        Task<bool> Update(PlatformUser user);

        Task<bool> Disable(int userId);

        Task<bool> Enable(int userId);

        Task<bool> BindWechat(int userId, string openId);

        Task<PlatformUser> GetById(int userId);

        Task<IEnumerable<PlatformUser>> GetByEnterprise(int enterpriseId);

        Task<IEnumerable<PlatformUser>> Search(string keyword);

        Task<IEnumerable<OperationLog>> GetOperationLogs(int userId);

        Task<IEnumerable<EnterpriseHistory>> GetEnterpriseHistories(int userId);
    }
}