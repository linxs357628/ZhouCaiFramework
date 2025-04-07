using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// ƽ̨�û�����
    /// </summary>

    public class PlatformUserController : AdminBaseController
    {
        private readonly IPlatformUserService _platformUserService;

        public PlatformUserController(IPlatformUserService platformUserService, ILogger<PlatformUserController> logger)
            : base(logger)
        {
            _platformUserService = platformUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PlatformUserRegisterDto dto)
        {
            var user = new PlatformUser
            {
                Nickname = dto.Nickname,
                Name = dto.Name,
                Phone = dto.Phone,
                Position = dto.Position,
                EnterpriseId = dto.EnterpriseId,
                IsMainAccount = dto.IsMainAccount
            };

            var result = await _platformUserService.Register(user, dto.Password);
            return Success(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlatformUserUpdateDto dto)
        {
            var user = await _platformUserService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Nickname = dto.Nickname;
            user.Name = dto.Name;
            user.Position = dto.Position;

            var success = await _platformUserService.Update(user);
            return success ? Success(success) : BadRequest<bool>();
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _platformUserService.Disable(id);
            return success ? Success(success) : BadRequest<bool>();
        }

        [HttpPut("{id}/enable")]
        public async Task<IActionResult> Enable(int id)
        {
            var success = await _platformUserService.Enable(id);
            return success ? Success(success) : BadRequest<bool>();
        }

        [HttpPut("{id}/bind-wechat")]
        public async Task<IActionResult> BindWechat(int id, [FromBody] WechatBindDto dto)
        {
            var success = await _platformUserService.BindWechat(id, dto.OpenId);
            return success ? Success(success) : BadRequest<bool>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _platformUserService.GetById(id);
            return user != null ? Success(user) : NotFound<PlatformUser>();
        }

        [HttpGet("enterprise/{enterpriseId}")]
        public async Task<IActionResult> GetByEnterprise(int enterpriseId)
        {
            var users = await _platformUserService.GetByEnterprise(enterpriseId);
            return Success(users);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var users = await _platformUserService.Search(keyword);
            return Success(users);
        }

        [HttpGet("{id}/operation-logs")]
        public async Task<IActionResult> GetOperationLogs(int id)
        {
            var logs = await _platformUserService.GetOperationLogs(id);
            return Success(logs);
        }

        [HttpGet("{id}/enterprise-histories")]
        public async Task<IActionResult> GetEnterpriseHistories(int id)
        {
            var histories = await _platformUserService.GetEnterpriseHistories(id);
            return Success(histories);
        }
    }
}