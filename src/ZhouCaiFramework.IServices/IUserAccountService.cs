using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IUserAccountService
    {
        Task<User> GetById(int userId);

        Task<IEnumerable<User>> GetByEnterprise(int enterpriseId);

        Task<User> Create(User user);

        Task<bool> Update(User user);

        Task<bool> Disable(int userId);

        Task<bool> TransferAccount(int fromUserId, string toUserPhone, int enterpriseId);

        Task<bool> UnlinkEnterprise(int userId, int enterpriseId);

        // 关联操作
        Task<bool> LinkEnterprise(int userId, int enterpriseId, string position, string role);

        Task<bool> UpdateEnterpriseLink(int userId, int enterpriseId, string position, string role);

        // 查询
        Task<IEnumerable<UserLog>> GetUserLogs(int userId);

        Task<bool> CheckLongNoLogin(int days = 7);

        Task LogActionAsync(int userId, string actionType, string actionName, object actionData, string result, bool isDangerous = false);
    }
}