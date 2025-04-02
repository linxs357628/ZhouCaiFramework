using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class MaterialCategoryController : ControllerBase
    {
        private readonly IMaterialCategoryService _categoryService;

        public MaterialCategoryController(IMaterialCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] MaterialCategoryQueryDto query)
        {
            var result = await _categoryService.GetCategoriesAsync(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryAsync(id);
            return Ok(result);
        }

        [HttpGet("parents")]
        public async Task<IActionResult> GetParentCategories()
        {
            var result = await _categoryService.GetParentCategoriesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] MaterialCategoryDto dto)
        {
            var id = await _categoryService.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetCategory), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] MaterialCategoryDto dto)
        {
            dto.Id = id;
            var success = await _categoryService.UpdateCategoryAsync(dto);
            return success ? NoContent() : BadRequest();
        }

        [HttpPatch("{id}/toggle-visibility")]
        public async Task<IActionResult> ToggleVisibility(int id)
        {
            var success = await _categoryService.ToggleVisibilityAsync(id);
            return success ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            return success ? NoContent() : BadRequest();
        }
    }
}
