using System.Reflection;
using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Web.Validators;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class LoginController : AdminBaseController
    {
        private readonly IAuthService _authService;
        private readonly IValidator<LoginRequest> _validator;

        public LoginController(
            ISqlSugarClient db,
            IAuthService authService,
            IValidator<LoginRequest> validator,
            ILogger<AdminBaseController> logger) : base(db, logger)
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

            // 管理员身份验证
            var (user, error) = await _authService.AuthenticateAdmin(request.Username, request.Password);
            if (user == null)
            {
                return string.IsNullOrEmpty(error) ?
                    Unauthorized() :
                    Unauthorized(error);
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

        [HttpGet("InitDatabase")]
        [AllowAnonymous]
        public async Task<IActionResult> InitDatabase()
        {
            var list = Assembly.Load("ZhouCaiFramework.Model").GetTypes().Where(u => u.IsClass && u.Namespace == "ZhouCaiFramework.Model.Entities").ToArray();
            _db.InitDatabase(types: list);
            return Ok(new { Code = 200, Message = "数据库初始化成功" });
        }
    }
}