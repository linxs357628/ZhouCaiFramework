using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 素材分类控制器
    /// </summary>

    public class MaterialCategoryController : AdminBaseController
    {
        private readonly IMaterialCategoryService _categoryService;

        public MaterialCategoryController(IMaterialCategoryService categoryService, ILogger<MaterialCategoryController> logger) : base(logger)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 获取素材分类列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] MaterialCategoryQueryDto query)
        {
            var result = await _categoryService.GetCategoriesAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// 获取单个素材分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// 获取所有父级分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("parents")]
        public async Task<IActionResult> GetParentCategories()
        {
            var result = await _categoryService.GetParentCategoriesAsync();
            return Ok(result);
        }

        /// <summary>
        /// 创建素材分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] MaterialCategoryDto dto)
        {
            var id = await _categoryService.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetCategory), new { id }, null);
        }

        /// <summary>
        /// 更新素材分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] MaterialCategoryDto dto)
        {
            dto.Id = id;
            var success = await _categoryService.UpdateCategoryAsync(dto);
            return success ? NoContent() : BadRequest();
        }

        /// <summary>
        /// 切换素材分类的可见性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}/toggle-visibility")]
        public async Task<IActionResult> ToggleVisibility(int id)
        {
            var success = await _categoryService.ToggleVisibilityAsync(id);
            return success ? NoContent() : BadRequest();
        }

        /// <summary>
        /// 删除素材分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            return success ? NoContent() : BadRequest();
        }
    }
}