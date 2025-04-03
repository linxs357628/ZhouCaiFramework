using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// ’æµ„Àÿ≤ƒπ‹¿Ì
    /// </summary>

    public class SiteMaterialController : AdminBaseController
    {
        private readonly ISiteMaterialService _siteMaterialService;

        public SiteMaterialController(
            ISiteMaterialService siteMaterialService,
            ILogger<SiteMaterialController> logger) : base(logger)
        {
            _siteMaterialService = siteMaterialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSiteMaterials(
            [FromQuery] SiteMaterialQuery query)
        {
            var result = await _siteMaterialService.GetSiteMaterials(query);
            return Ok(result);
        }

        [HttpGet("project")]
        public async Task<IActionResult> GetProjectMaterials(
            [FromQuery] ProjectMaterialQuery query)
        {
            var result = await _siteMaterialService.GetProjectMaterials(query);
            return Ok(result);
        }

        [HttpGet("{materialCode}/history")]
        public async Task<IActionResult> GetMaterialHistory(string materialCode)
        {
            var history = await _siteMaterialService.GetMaterialHistory(materialCode);
            return Ok(history);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, [FromBody] SiteMaterialUpdateDto dto)
        {
            var result = await _siteMaterialService.UpdateMaterial(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var result = await _siteMaterialService.DeleteMaterial(id);
            return Ok(result);
        }
    }
}