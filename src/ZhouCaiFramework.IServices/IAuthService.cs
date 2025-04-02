using System.Security.Claims;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IAuthService
    {
        Task<(User user, string error)> Authenticate(string username, string password);

        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        Task<RefreshToken> StoreRefreshToken(int userId, string token);

        Task<bool> RevokeRefreshToken(string token);

        Task<(string newAccessToken, string newRefreshToken, string error)> RefreshToken(string token);

        Task<(User user, string error)> AuthenticateAdmin(string username, string password);
    }
}