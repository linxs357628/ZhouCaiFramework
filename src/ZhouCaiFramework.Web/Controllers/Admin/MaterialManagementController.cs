using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    public class MaterialManagementController : AdminBaseController
    {
        private readonly IMaterialService _materialService;

        public MaterialManagementController(
            IMaterialService materialService,
            ILogger<AdminBaseController> logger) : base(null, logger)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// 获取周转材料列表
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetMaterials([FromQuery] MaterialQueryDto query)
        {
            var result = await _materialService.GetMaterialsAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// 获取材料详情
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            var material = await _materialService.GetMaterialDetailAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        /// <summary>
        /// 获取材料统计信息
        /// </summary>
        [HttpGet("stats")]
        public async Task<IActionResult> GetMaterialStats([FromQuery] MaterialQueryDto query)
        {
            var stats = await _materialService.GetMaterialStatsAsync(query);
            return Ok(stats);
        }

        /// <summary>
        /// 导出材料数据
        /// </summary>
        [HttpGet("export")]
        public async Task<IActionResult> ExportMaterials([FromQuery] MaterialQueryDto query)
        {
            var fileBytes = await _materialService.ExportMaterialsAsync(query);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "materials.xlsx");
        }

        /// <summary>
        /// 获取有材料的分类列表(用于动态生成tab)
        /// </summary>
        [HttpGet("categories")]
        public async Task<IActionResult> GetActiveCategories()
        {
            var categories = await _materialService.GetActiveCategoriesAsync();
            return Ok(categories);
        }

        /// <summary>
        /// 获取指定分类下的活跃二级分类
        /// </summary>
        [HttpGet("categories/{category}/subcategories")]
        public async Task<IActionResult> GetActiveSubCategories(string category)
        {
            var subCategories = await _materialService.GetActiveSubCategoriesAsync(category);
            return Ok(subCategories);
        }

        /// <summary>
        /// 获取材料操作历史
        /// </summary>
        [HttpGet("{materialId}/history")]
        public async Task<IActionResult> GetMaterialHistory(int materialId)
        {
            var history = await _materialService.GetMaterialHistoryAsync(materialId);
            return Ok(history);
        }

        /// <summary>
        /// 获取材料图片列表
        /// </summary>
        [HttpGet("{materialId}/images")]
        public async Task<IActionResult> GetMaterialImages(int materialId)
        {
            var images = await _materialService.GetMaterialImagesAsync(materialId);
            return Ok(images);
        }

        /// <summary>
        /// 上传材料图片
        /// </summary>
        [HttpPost("{materialId}/images")]
        public async Task<IActionResult> UploadMaterialImage(int materialId, IFormFile file, [FromForm] string description)
        {
            using var stream = file.OpenReadStream();
            var result = await _materialService.UploadMaterialImageAsync(
                new UploadImageDto { MaterialId = materialId, Description = description },
                stream,
                file.FileName);
            return Ok(result);
        }

        /// <summary>
        /// 删除材料图片
        /// </summary>
        [HttpDelete("images/{imageId}")]
        public async Task<IActionResult> DeleteMaterialImage(int imageId)
        {
            var result = await _materialService.DeleteMaterialImageAsync(imageId);
            return Ok(result);
        }

        /// <summary>
        /// 更新图片信息
        /// </summary>
        [HttpPut("images/{imageId}")]
        public async Task<IActionResult> UpdateMaterialImage(int imageId, [FromBody] UpdateImageDto dto)
        {
            var result = await _materialService.UpdateMaterialImageAsync(imageId, dto);
            return Ok(result);
        }
    }
}