using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;

using System.Security.Claims;
using System.Security.Cryptography;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISqlSugarClient _db;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(ISqlSugarClient db, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _db = db;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<(User user, string error)> Authenticate(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return (null, "Username and password are required");
                }

                var user = await _db.Queryable<User>()
                    .Where(x => x.Username == username && x.EnterpriseId != 0)
                    .FirstAsync();

                if (user == null || !VerifyPassword(password, user.Password, user.Salt))
                {
                    _logger.LogWarning($"Failed login attempt for username: {username}");
                    return (null, "Invalid username or password");
                }

                if (user.IsLocked)
                {
                    return (null, "Account is locked");
                }

                // Update last login
                user.LastLoginTime = DateTime.Now;
                await _db.Updateable(user).ExecuteCommandAsync();

                return (user, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during authentication");
                return (null, "An error occurred during authentication");
            }
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            return JwtExtensions.GenerateToken(claims, _configuration);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<RefreshToken> StoreRefreshToken(int userId, string token)
        {
            var refreshToken = new RefreshToken
            {
                Token = token,
                UserId = userId,
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            await _db.Insertable(refreshToken).ExecuteCommandAsync();
            return refreshToken;
        }

        public async Task<bool> RevokeRefreshToken(string token)
        {
            try
            {
                var storedToken = await _db.Queryable<RefreshToken>()
                    .FirstAsync(x => x.Token == token && x.Revoked == null);

                if (storedToken == null) return false;

                storedToken.Revoked = DateTime.Now;
                await _db.Updateable(storedToken).ExecuteCommandAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<(string newAccessToken, string newRefreshToken, string error)> RefreshToken(string token)
        {
            try
            {
                var storedToken = await _db.Queryable<RefreshToken>()
                    .FirstAsync(x => x.Token == token && x.Revoked == null);

                if (storedToken == null || storedToken.Expires <= DateTime.Now)
                {
                    return (null, null, "Invalid or expired refresh token");
                }

                var user = await _db.Queryable<User>()
                    .FirstAsync(x => x.Id == storedToken.UserId);

                if (user == null || user.IsLocked)
                {
                    return (null, null, "User not found or account locked");
                }

                // Revoke old token
                storedToken.Revoked = DateTime.Now;
                await _db.Updateable(storedToken).ExecuteCommandAsync();

                // Generate new tokens
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.Username),
                    new(ClaimTypes.Role, "front"),
                    new(ClaimTypes.Sid, user.EnterpriseId.ToString()),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var newAccessToken = GenerateAccessToken(claims);
                var newRefreshToken = GenerateRefreshToken();

                // Store new refresh token
                await StoreRefreshToken(user.Id, newRefreshToken);

                return (newAccessToken, newRefreshToken, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refreshing token");
                return (null, null, "An error occurred while refreshing token");
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash, string salt)
        {
            var hashBytes = Convert.FromBase64String(storedHash);
            var saltBytes = Convert.FromBase64String(salt);

            using var deriveBytes = new Rfc2898DeriveBytes(inputPassword, saltBytes, 10000);
            var newHash = deriveBytes.GetBytes(32);

            return newHash.SequenceEqual(hashBytes);
        }

        public async Task<(User user, string error)> AuthenticateAdmin(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return (null, "Username and password are required");
                }

                var user = await _db.Queryable<User>()
                    .Where(x => x.Username == username && x.EnterpriseId == 0)
                    .FirstAsync();

                if (user == null || !VerifyPassword(password, user.Password, user.Salt))
                {
                    _logger.LogWarning($"Failed login attempt for username: {username}");
                    return (null, "Invalid username or password");
                }

                if (user.IsLocked)
                {
                    return (null, "Account is locked");
                }

                // Update last login
                user.LastLoginTime = DateTime.Now;
                await _db.Updateable(user).ExecuteCommandAsync();

                return (user, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during authentication");
                return (null, "An error occurred during authentication");
            }
        }
    }
}