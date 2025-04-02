using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class MaterialLockController : ControllerBase
    {
        private readonly IMaterialLockService _materialLockService;

        public MaterialLockController(IMaterialLockService materialLockService)
        {
            _materialLockService = materialLockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialLocks([FromQuery] MaterialLockQueryDto query)
        {
            var result = await _materialLockService.GetMaterialLocksAsync(query);
            return Ok(result);
        }

        [HttpGet("{lockId}/details")]
        public async Task<IActionResult> GetMaterialDetails(int lockId)
        {
            var result = await _materialLockService.GetMaterialDetailsAsync(lockId);
            return Ok(result);
        }

        [HttpPatch("{lockId}/toggle-lock")]
        public async Task<IActionResult> ToggleLockStatus(int lockId)
        {
            var success = await _materialLockService.ToggleLockStatusAsync(lockId);
            return success ? NoContent() : BadRequest();
        }
    }
}
