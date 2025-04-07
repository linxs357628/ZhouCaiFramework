using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 材料锁库管理控制器
    /// 提供材料锁库相关的API接口
    /// </summary>

    public class MaterialLockController : AdminBaseController
    {
        private readonly IMaterialLockService _materialLockService;

        public MaterialLockController(IMaterialLockService materialLockService, ILogger<MaterialLockController> logger) : base(logger)
        {
            _materialLockService = materialLockService;
        }

        /// <summary>
        /// 获取材料锁库记录列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns>锁库记录分页列表</returns>
        [HttpGet]
        public async Task<IActionResult> GetMaterialLocks([FromQuery] MaterialLockQueryDto query)
        {
            var result = await _materialLockService.GetMaterialLocksAsync(query);
            return Success(result);
        }

        /// <summary>
        /// 获取指定锁库记录的材料明细
        /// </summary>
        /// <param name="lockId">锁库记录ID</param>
        /// <returns>材料明细列表</returns>
        [HttpGet("{lockId}/details")]
        public async Task<IActionResult> GetMaterialDetails(int lockId)
        {
            var result = await _materialLockService.GetMaterialDetailsAsync(lockId);
            return Success(result);
        }

        /// <summary>
        /// 切换锁库状态
        /// </summary>
        /// <param name="lockId">锁库记录ID</param>
        /// <returns>204 NoContent表示成功，400 BadRequest表示失败</returns>
        [HttpPatch("{lockId}/toggle-lock")]
        public async Task<IActionResult> ToggleLockStatus(int lockId)
        {
            var success = await _materialLockService.ToggleLockStatusAsync(lockId);
            return success ? Success(success) : BadRequest<bool>();
        }
    }
}