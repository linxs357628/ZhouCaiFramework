using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Web.Validators;

namespace ZhouCaiFramework.Web.Controllers.Front
{
    [ApiController]
    [Route("api/front/[controller]")]
    public class LoginController : FrontBaseController
    {
        private readonly IAuthService _authService;
        private readonly IValidator<LoginRequest> _validator;

        public LoginController(
            IAuthService authService,
            IValidator<LoginRequest> validator,
            ILogger<FrontBaseController> logger) : base(null, logger)
        {
            _authService = authService;
            _validator = validator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // 验证请求参数
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Code = 400,
                    Message = "参数验证失败",
                    Errors = validationResult.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Message = e.ErrorMessage
                    })
                });
            }

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