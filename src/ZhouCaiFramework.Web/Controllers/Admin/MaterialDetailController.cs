using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 物料明细管理
    /// </summary>

    public class MaterialDetailController : AdminBaseController
    {
        private readonly IMaterialOutboundService _outboundService;

        public MaterialDetailController(IMaterialOutboundService outboundService, ILogger<MaterialDetailController> logger) : base(logger)
        {
            _outboundService = outboundService;
        }

        /// <summary>
        /// 获取物料明细
        /// </summary>
        /// <param name="outboundId"></param>
        /// <returns></returns>
        [HttpGet("{outboundId}")]
        public async Task<IActionResult> GetMaterialDetails(int outboundId)
        {
            var result = await _outboundService.GetMaterialDetailsAsync(outboundId);
            return Ok(result);
        }

        /// <summary>
        /// 创建物料明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMaterialDetail([FromBody] MaterialDetailEditDto dto)
        {
            var id = await _outboundService.CreateMaterialDetailAsync(dto);
            return CreatedAtAction(nameof(GetMaterialDetails), new { outboundId = dto.LockId }, id);
        }

        /// <summary>
        /// 更新物料明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialDetail(int id, [FromBody] MaterialDetailEditDto dto)
        {
            dto.Id = id;
            var success = await _outboundService.UpdateMaterialDetailAsync(dto);
            return success ? NoContent() : BadRequest();
        }

        /// <summary>
        /// 删除物料明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialDetail(int id)
        {
            var success = await _outboundService.DeleteMaterialDetailAsync(id);
            return success ? NoContent() : BadRequest();
        }
    }
}