using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 用户账号管理
    /// </summary>

    public class UserAccountController : AdminBaseController
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(
            IUserAccountService userAccountService,
            ILogger<UserAccountController> logger,
            IHttpContextAccessor httpContextAccessor) : base(logger)
        {
            _userAccountService = userAccountService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userAccountService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = new UserAccountDetailDto
            {
                Id = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                RealName = user.RealName,
                Phone = user.Phone,
                WechatOpenId = user.WechatOpenId,
                IsMainAccount = user.IsMainAccount,
                RegisterTime = user.RegisterTime,
                LastLoginTime = user.LastLoginTime,
                LastLoginPlatform = user.LastLoginPlatform,
                Status = user.Status,
                EnterpriseLinks = ParseEnterpriseLinks(user),
                Logs = await _userAccountService.GetUserLogs(id)
            };

            return Ok(result);
        }

        [HttpGet("enterprise/{enterpriseId}")]
        public async Task<IActionResult> GetByEnterprise(int enterpriseId)
        {
            var users = await _userAccountService.GetByEnterprise(enterpriseId);
            return Ok(users.Select(x => new UserAccountSimpleDto
            {
                Id = x.Id,
                Username = x.Username,
                Nickname = x.Nickname,
                RealName = x.RealName,
                Phone = x.Phone,
                IsMainAccount = x.IsMainAccount,
                Status = x.Status,
                Position = GetPositionForEnterprise(x, enterpriseId),
                Role = GetRoleForEnterprise(x, enterpriseId)
            }));
        }

        private List<EnterpriseLinkDto> ParseEnterpriseLinks(User user)
        {
            var links = new List<EnterpriseLinkDto>();

            if (string.IsNullOrEmpty(user.EnterpriseIds))
                return links;

            var enterpriseIds = user.EnterpriseIds.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var idStr in enterpriseIds)
            {
                if (int.TryParse(idStr, out var enterpriseId))
                {
                    links.Add(new EnterpriseLinkDto
                    {
                        EnterpriseId = enterpriseId,
                        Position = GetPositionForEnterprise(user, enterpriseId),
                        Role = GetRoleForEnterprise(user, enterpriseId)
                    });
                }
            }
            return links;
        }

        private string GetRoleForEnterprise(User user, int enterpriseId)
        {
            if (string.IsNullOrEmpty(user.Roles))
                return string.Empty;

            var roles = user.Roles.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in roles)
            {
                var parts = role.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out var id) &&
                    id == enterpriseId)
                {
                    return parts[1];
                }
            }
            return string.Empty;
        }

        private string GetPositionForEnterprise(User user, int enterpriseId)
        {
            if (string.IsNullOrEmpty(user.Positions))
                return string.Empty;

            var positions = user.Positions.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var position in positions)
            {
                var parts = position.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out var id) &&
                    id == enterpriseId)
                {
                    return parts[1];
                }
            }
            return string.Empty;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] UserAccountCreateDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Nickname = dto.Nickname,
                RealName = dto.RealName,
                Phone = dto.Phone,
                Password = dto.Password  // 由Service统一加密
            };

            var result = await _userAccountService.Create(user);
            await _userAccountService.LogActionAsync(
                result.Id,
                "新增",
                "创建用户账号",
                new { Username = user.Username, Phone = user.Phone },
                "成功"
            );
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserAccountUpdateDto dto)
        {
            var user = await _userAccountService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Nickname = dto.Nickname;
            user.RealName = dto.RealName;
            user.Phone = dto.Phone;

            var success = await _userAccountService.Update(user);
            await _userAccountService.LogActionAsync(
                id,
                "更新",
                "更新用户账号信息",
                new
                {
                    OldData = new { user.Nickname, user.RealName, user.Phone },
                    NewData = dto
                },
                success ? "成功" : "失败"
            );
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _userAccountService.Disable(id);
            await _userAccountService.LogActionAsync(
                id,
                "禁用",
                "禁用用户账号",
                null,
                success ? "成功" : "失败",
                true // 标记为危险操作
            );
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/transfer")]
        public async Task<IActionResult> Transfer(int id, [FromBody] UserAccountTransferDto dto)
        {
            var success = await _userAccountService.TransferAccount(id, dto.ToUserPhone, dto.EnterpriseId);
            await _userAccountService.LogActionAsync(
                id,
                "转让",
                "转让账号权限",
                new
                {
                    FromUserId = id,
                    ToUserPhone = dto.ToUserPhone,
                    EnterpriseId = dto.EnterpriseId
                },
                success ? "成功" : "失败",
                true // 标记为危险操作
            );
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/unlink")]
        public async Task<IActionResult> Unlink(int id, [FromBody] UserAccountUnlinkDto dto)
        {
            var success = await _userAccountService.UnlinkEnterprise(id, dto.EnterpriseId);
            await _userAccountService.LogActionAsync(
                id,
                "解关联",
                "解除账号与企业关联",
                new { EnterpriseId = dto.EnterpriseId },
                success ? "成功" : "失败",
                true // 标记为危险操作
            );
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/link")]
        public async Task<IActionResult> LinkEnterprise(int id, [FromBody] UserAccountLinkDto dto)
        {
            var success = await _userAccountService.LinkEnterprise(id, dto.EnterpriseId, dto.Position, dto.Role);
            await _userAccountService.LogActionAsync(
                id,
                "关联",
                "关联账号与企业",
                new
                {
                    EnterpriseId = dto.EnterpriseId,
                    Position = dto.Position,
                    Role = dto.Role
                },
                success ? "成功" : "失败"
            );
            return success ? Ok() : BadRequest();
        }

        [HttpGet("{id}/logs")]
        public async Task<IActionResult> GetLogs(int id)
        {
            var logs = await _userAccountService.GetUserLogs(id);
            return Ok(logs);
        }
    }
}