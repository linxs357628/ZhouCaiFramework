using Microsoft.Extensions.Logging;
using SqlSugar;
using System.Security.Cryptography;
using System.Text;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<UserAccountService> _logger;

        public UserAccountService(ISqlSugarClient db, ILogger<UserAccountService> logger)
        {
            _db = db;
            _logger = logger;
        }

        // 密码加密
        private string EncryptPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "ZhouCaiSalt"));
            return Convert.ToBase64String(bytes);
        }

        // 基本CRUD操作
        public async Task<User> GetById(int id)
        {
            return await _db.Queryable<User>().FirstAsync(u => u.Id == id);
        }

        public async Task<bool> CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Password))
                return false;

            user.Password = EncryptPassword(user.Password);
            return await _db.Insertable(user).ExecuteCommandIdentityIntoEntityAsync();
        }

        public async Task<bool> VerifyPassword(string phone, string password)
        {
            var user = await GetByPhoneAsync(phone);
            if (user == null) return false;

            return user.Password == EncryptPassword(password);
        }

        // 获取用户信息
        public async Task<User> GetByPhoneAsync(string phone)
        {
            return await _db.Queryable<User>()
                .Where(u => u.Phone == phone)
                .FirstAsync();
        }

        // 完善转让账号方法
        public async Task<bool> TransferAccount(int fromUserId, string toUserPhone, int enterpriseId)
        {
            var toUser = await GetByPhoneAsync(toUserPhone);
            if (toUser == null) return false;

            var fromUser = await GetById(fromUserId);
            if (fromUser == null) return false;

            // 转让企业关联信息
            var positions = ParseEnterpriseData(fromUser.Positions);
            var roles = ParseEnterpriseData(fromUser.Roles);

            if (positions.ContainsKey(enterpriseId) || roles.ContainsKey(enterpriseId))
            {
                // 更新目标用户的关联信息
                toUser.EnterpriseIds += $",{enterpriseId}";
                toUser.Positions = UpdateEnterpriseData(toUser.Positions, enterpriseId, positions[enterpriseId]);
                toUser.Roles = UpdateEnterpriseData(toUser.Roles, enterpriseId, roles[enterpriseId]);

                // 移除原用户的关联信息
                fromUser.EnterpriseIds = fromUser.EnterpriseIds
                    .Split(',')
                    .Where(x => x != enterpriseId.ToString())
                    .Aggregate((a, b) => $"{a},{b}");
                fromUser.Positions = RemoveEnterpriseData(fromUser.Positions, enterpriseId);
                fromUser.Roles = RemoveEnterpriseData(fromUser.Roles, enterpriseId);

                await _db.Updateable(toUser).ExecuteCommandAsync();
                await _db.Updateable(fromUser).ExecuteCommandAsync();
                return true;
            }

            return false;
        }

        private string UpdateEnterpriseData(string data, int enterpriseId, string value)
        {
            var dict = ParseEnterpriseData(data);
            dict[enterpriseId] = value;
            return string.Join(",", dict.Select(x => $"{x.Key}:{x.Value}"));
        }

        private Dictionary<int, string> ParseEnterpriseData(string data)
        {
            var dict = new Dictionary<int, string>();
            if (string.IsNullOrWhiteSpace(data))
                return dict;

            try
            {
                var entries = data.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var entry in entries)
                {
                    var parts = entry.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2 && int.TryParse(parts[0], out var id))
                    {
                        dict[id] = parts[1];
                    }
                }
                return dict;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "解析企业数据失败: {Data}", data);
                return [];
            }
        }

        private string RemoveEnterpriseData(string data, int enterpriseId)
        {
            var dict = ParseEnterpriseData(data);
            dict.Remove(enterpriseId);
            return string.Join(",", dict.Select(x => $"{x.Key}:{x.Value}"));
        }

        public async Task<IEnumerable<User>> GetByEnterprise(int enterpriseId)
        {
            return await _db.Queryable<User>()
                .Where(u => u.EnterpriseIds.Contains($",{enterpriseId},") ||
                           u.EnterpriseIds.StartsWith($"{enterpriseId},") ||
                           u.EnterpriseIds.EndsWith($",{enterpriseId}") ||
                           u.EnterpriseIds == enterpriseId.ToString())
                .ToListAsync();
        }

        public Task<User> Create(User user)
        {
            return _db.Insertable(user).ExecuteReturnEntityAsync();
        }

        public async Task<bool> Update(User user)
        {
            if (user == null)
                return false;

            // 不更新密码字段
            return await _db.Updateable(user)
                .IgnoreColumns(u => u.Password)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Disable(int userId)
        {
            return await _db.Updateable<User>()
                .SetColumns(u => new User { Status = "disabled" })
                .Where(u => u.Id == userId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> TransferAccount(int fromUserId, int toUserId, int enterpriseId)
        {
            var toUser = await GetById(toUserId);
            if (toUser == null) return false;

            var fromUser = await GetById(fromUserId);
            if (fromUser == null) return false;

            // 转让企业关联信息
            var positions = ParseEnterpriseData(fromUser.Positions);
            var roles = ParseEnterpriseData(fromUser.Roles);

            if (positions.ContainsKey(enterpriseId) || roles.ContainsKey(enterpriseId))
            {
                // 更新目标用户的关联信息
                toUser.EnterpriseIds += $",{enterpriseId}";
                toUser.Positions = UpdateEnterpriseData(toUser.Positions, enterpriseId, positions[enterpriseId]);
                toUser.Roles = UpdateEnterpriseData(toUser.Roles, enterpriseId, roles[enterpriseId]);

                // 移除原用户的关联信息
                fromUser.EnterpriseIds = fromUser.EnterpriseIds
                    .Split(',')
                    .Where(x => x != enterpriseId.ToString())
                    .Aggregate((a, b) => $"{a},{b}");
                fromUser.Positions = RemoveEnterpriseData(fromUser.Positions, enterpriseId);
                fromUser.Roles = RemoveEnterpriseData(fromUser.Roles, enterpriseId);

                await _db.Updateable(toUser).ExecuteCommandAsync();
                await _db.Updateable(fromUser).ExecuteCommandAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UnlinkEnterprise(int userId, int enterpriseId)
        {
            var user = await GetById(userId);
            if (user == null) return false;

            // 更新企业关联信息
            user.EnterpriseIds = user.EnterpriseIds
                .Split(',')
                .Where(x => x != enterpriseId.ToString())
                .Aggregate((a, b) => $"{a},{b}");
            user.Positions = RemoveEnterpriseData(user.Positions, enterpriseId);
            user.Roles = RemoveEnterpriseData(user.Roles, enterpriseId);

            return await _db.Updateable(user).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> LinkEnterprise(int userId, int enterpriseId, string position, string role)
        {
            var user = await GetById(userId);
            if (user == null) return false;

            try
            {
                // 更新企业关联信息
                if (!string.IsNullOrEmpty(user.EnterpriseIds) && !user.EnterpriseIds.Contains(enterpriseId.ToString()))
                    user.EnterpriseIds += $",{enterpriseId}";
                else if (string.IsNullOrEmpty(user.EnterpriseIds))
                    user.EnterpriseIds = enterpriseId.ToString();

                user.Positions = UpdateEnterpriseData(user.Positions, enterpriseId, position);
                user.Roles = UpdateEnterpriseData(user.Roles, enterpriseId, role);

                return await _db.Updateable(user).ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "关联企业失败: UserId={UserId}, EnterpriseId={EnterpriseId}", userId, enterpriseId);
                return false;
            }
        }

        public async Task<bool> UpdateEnterpriseLink(int userId, int enterpriseId, string position, string role)
        {
            var user = await GetById(userId);
            if (user == null || !user.EnterpriseIds.Contains(enterpriseId.ToString()))
                return false;

            try
            {
                // 只更新职位和角色信息
                user.Positions = UpdateEnterpriseData(user.Positions, enterpriseId, position);
                user.Roles = UpdateEnterpriseData(user.Roles, enterpriseId, role);

                return await _db.Updateable(user)
                    .UpdateColumns(u => new { u.Positions, u.Roles })
                    .ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新企业关联失败: UserId={UserId}, EnterpriseId={EnterpriseId}", userId, enterpriseId);
                return false;
            }
        }

        public async Task<IEnumerable<UserLog>> GetUserLogs(int userId)
        {
            return await _db.Queryable<UserLog>()
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.CreateTime)
                .Take(100) // 限制返回最近的100条日志
                .ToListAsync();
        }

        public async Task<bool> CheckLongNoLogin(int days = 7)
        {
            var deadline = DateTime.Now.AddDays(-days);
            return await _db.Queryable<User>()
                .AnyAsync(u => u.Status == "active" &&
                             (u.LastLoginTime == null || u.LastLoginTime < deadline));
        }

        public async Task LogActionAsync(int userId, string actionType, string actionName, object actionData, string result, bool isDangerous = false)
        {
            try
            {
                var log = new UserLog
                {
                    UserId = userId,
                    ActionType = actionType,
                    ActionName = actionName,
                    ActionData = System.Text.Json.JsonSerializer.Serialize(actionData),
                    Result = result,
                    CreateTime = DateTime.Now,
                    IsDangerous = isDangerous,
                };
                await _db.Insertable(log).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "记录用户操作日志失败: UserId={UserId}, Action={Action}", userId, actionName);
            }
        }
    }
}