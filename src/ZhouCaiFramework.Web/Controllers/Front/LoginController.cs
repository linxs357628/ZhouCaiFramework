using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Front
{
    public class LoginController : FrontBaseController
    {
        private readonly IAuthService _authService;

        public LoginController(
            IAuthService authService,
            ILogger<FrontBaseController> logger) : base(null, logger)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // 身份验证逻辑
            var (user, error) = await _authService.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                return string.IsNullOrEmpty(error) ?
                    Unauthorized() :
                    Unauthorized(error);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, "front"),
                new(ClaimTypes.Sid, user.EnterpriseId.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var accessToken = _authService.GenerateAccessToken(claims);
            var refreshToken = _authService.GenerateRefreshToken();

            await _authService.StoreRefreshToken(user.Id, refreshToken);
            _logger.LogInformation("用户 {Username} 登录成功", user.Username);

            return Ok(new
            {
                Code = 200,
                Message = "登录成功",
                Data = new
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = 120 * 60 // 120分钟
                }
            });
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh(string token)
        {
            var (newAccessToken, newRefreshToken, error) = await _authService.RefreshToken(token);
            if (string.IsNullOrEmpty(newAccessToken))
            {
                return string.IsNullOrEmpty(error) ?
                    Unauthorized() :
                    Unauthorized(error);
            }

            return Ok(new
            {
                Code = 200,
                Message = "令牌刷新成功",
                Data = new
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    ExpiresIn = 120 * 60 // 120分钟
                }
            });
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke(string token)
        {
            var success = await _authService.RevokeRefreshToken(token);
            return success ?
                Ok(new { Code = 200, Message = "令牌已注销" }) :
                BadRequest(new { Code = 400, Message = "无效的令牌" });
        }
    }
}