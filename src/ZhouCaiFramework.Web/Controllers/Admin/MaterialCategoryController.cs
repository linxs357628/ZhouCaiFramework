using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// �زķ��������
    /// </summary>

    public class MaterialCategoryController : AdminBaseController
    {
        private readonly IMaterialCategoryService _categoryService;

        public MaterialCategoryController(IMaterialCategoryService categoryService, ILogger<MaterialCategoryController> logger) : base(logger)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// ��ȡ�زķ����б�
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] MaterialCategoryQueryDto query)
        {
            var result = await _categoryService.GetCategoriesAsync(query);
            return Success(result);
        }

        /// <summary>
        /// ��ȡ�����زķ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryAsync(id);
            return Success(result);
        }

        /// <summary>
        /// ��ȡ���и�������
        /// </summary>
        /// <returns></returns>
        [HttpGet("parents")]
        public async Task<IActionResult> GetParentCategories()
        {
            var result = await _categoryService.GetParentCategoriesAsync();
            return Success(result);
        }

        /// <summary>
        /// �����زķ���
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
        /// �����زķ���
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] MaterialCategoryDto dto)
        {
            dto.Id = id;
            var success = await _categoryService.UpdateCategoryAsync(dto);
            return success ? Success(success) : BadRequest<bool>();
        }

        /// <summary>
        /// �л��زķ���Ŀɼ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}/toggle-visibility")]
        public async Task<IActionResult> ToggleVisibility(int id)
        {
            var success = await _categoryService.ToggleVisibilityAsync(id);
            return success ? Success(success) : BadRequest<bool>();
        }

        /// <summary>
        /// ɾ���زķ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            return success ? Success(success) : BadRequest<bool>();
        }
    }
}