using Microsoft.Extensions.Logging;
using SqlSugar;
using System.Security.Cryptography;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class PlatformUserService : IPlatformUserService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<PlatformUserService> _logger;

        public PlatformUserService(ISqlSugarClient db, ILogger<PlatformUserService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<PlatformUser> Register(PlatformUser user, string password)
        {
            try
            {
                // 检查手机号是否已注册
                if (await _db.Queryable<PlatformUser>()
                    .AnyAsync(x => x.Phone == user.Phone))
                {
                    throw new Exception("手机号已注册");
                }

                // 密码加密
                var salt = GenerateSalt();
                user.Password = HashPassword(password, salt);
                user.Salt = salt;
                user.RegisterTime = DateTime.Now;
                user.Status = 1; // 默认启用

                return await _db.Insertable(user).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "注册平台用户失败");
                throw;
            }
        }

        public async Task<bool> Update(PlatformUser user)
        {
            return await _db.Updateable(user)
                .IgnoreColumns(x => new { x.Password, x.Salt, x.RegisterTime })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Disable(int userId)
        {
            return await _db.Updateable<PlatformUser>()
                .SetColumns(x => x.Status == 0)
                .Where(x => x.Id == userId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Enable(int userId)
        {
            return await _db.Updateable<PlatformUser>()
                .SetColumns(x => x.Status == 1)
                .Where(x => x.Id == userId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> BindWechat(int userId, string openId)
        {
            return await _db.Updateable<PlatformUser>()
                .SetColumns(x => x.WechatOpenId == openId)
                .Where(x => x.Id == userId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<PlatformUser> GetById(int userId)
        {
            return await _db.Queryable<PlatformUser>()
                .Where(x => x.Id == userId)
                .FirstAsync();
        }

        public async Task<IEnumerable<PlatformUser>> GetByEnterprise(int enterpriseId)
        {
            return await _db.Queryable<PlatformUser>()
                .Where(x => x.EnterpriseId == enterpriseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlatformUser>> Search(string keyword)
        {
            return await _db.Queryable<PlatformUser>()
                .Where(x => x.Name.Contains(keyword) || x.Phone.Contains(keyword) || x.Nickname.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<OperationLog>> GetOperationLogs(int userId)
        {
            return await _db.Queryable<OperationLog>()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.OperationTime, OrderByType.Desc)
                .ToListAsync();
        }

        public async Task<IEnumerable<EnterpriseHistory>> GetEnterpriseHistories(int userId)
        {
            return await _db.Queryable<EnterpriseHistory>()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.JoinTime, OrderByType.Desc)
                .ToListAsync();
        }

        private string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            using var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashBytes = deriveBytes.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }
    }
}