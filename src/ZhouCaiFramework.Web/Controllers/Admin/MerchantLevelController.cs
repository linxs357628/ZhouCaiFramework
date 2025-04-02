using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class MerchantLevelController : AdminBaseController
    {
        private readonly IMerchantLevelService _merchantLevelService;

        public MerchantLevelController(IMerchantLevelService merchantLevelService, ILogger<MerchantLevelController> logger)
            : base(null, logger)
        {
            _merchantLevelService = merchantLevelService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MerchantLevelCreateDto dto)
        {
            var level = new MerchantLevel
            {
                EnterpriseType = dto.EnterpriseType,
                Level = dto.Level,
                Permissions = dto.Permissions
            };

            var result = await _merchantLevelService.Create(level);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MerchantLevelUpdateDto dto)
        {
            var level = await _merchantLevelService.GetById(id);
            if (level == null)
            {
                return NotFound();
            }

            level.EnterpriseType = dto.EnterpriseType;
            level.Level = dto.Level;
            level.Permissions = dto.Permissions;

            var success = await _merchantLevelService.Update(level);
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _merchantLevelService.Disable(id);
            return success ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _merchantLevelService.Delete(id);
            return success ? Ok() : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var level = await _merchantLevelService.GetById(id);
            return level != null ? Ok(level) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var levels = await _merchantLevelService.GetAll();
            return Ok(levels);
        }

        [HttpGet("by-enterprise-type/{enterpriseType}")]
        public async Task<IActionResult> GetByEnterpriseType(string enterpriseType)
        {
            var levels = await _merchantLevelService.GetByEnterpriseType(enterpriseType);
            return Ok(levels);
        }
    }
}