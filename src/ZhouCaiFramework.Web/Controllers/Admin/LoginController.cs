using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Reflection;
using System.Security.Claims;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 登录
    /// </summary>

    public class LoginController : AdminBaseController
    {
        private readonly IAuthService _authService;

        public LoginController(
            ISqlSugarClient db,
            IAuthService authService,
            ILogger<AdminBaseController> logger) : base(db, logger)
        {
            _authService = authService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // 管理员身份验证
            var (user, error) = await _authService.AuthenticateAdmin(request.Username, request.Password);
            if (user == null)
            {
                return string.IsNullOrEmpty(error) ?
                    Unauthorized<bool>() :
                    Unauthorized<bool>(error);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, "Admin"),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var accessToken = _authService.GenerateAccessToken(claims);
            var refreshToken = _authService.GenerateRefreshToken();

            await _authService.StoreRefreshToken(user.Id, refreshToken);
            _logger.LogInformation("管理员 {Username} 登录成功", user.Username);

            return Success(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = 120 * 60 // 120分钟
            },
                "登录成功"
            );
        }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh(string token)
        {
            var (newAccessToken, newRefreshToken, error) = await _authService.RefreshToken(token);
            if (string.IsNullOrEmpty(newAccessToken))
            {
                return string.IsNullOrEmpty(error) ?
                    Unauthorized<bool>() :
                    Unauthorized<bool>(error);
            }

            return Success(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                ExpiresIn = 120 * 60 // 120分钟
            },
                "令牌刷新成功"
            );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke(string token)
        {
            var success = await _authService.RevokeRefreshToken(token);
            return success ?
                Success(success, "令牌注销成功") :
                BadRequest<bool>("无效的令牌");
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns></returns>
        [HttpGet("InitDatabase")]
        [AllowAnonymous]
        public async Task<IActionResult> InitDatabase()
        {
            var list = Assembly.Load("ZhouCaiFramework.Model").GetTypes().Where(u => u.IsClass && u.Namespace == "ZhouCaiFramework.Model.Entities").ToArray();
            _db.InitDatabase(types: list);
            return Success(true, "数据库初始化成功");
        }
    }
}