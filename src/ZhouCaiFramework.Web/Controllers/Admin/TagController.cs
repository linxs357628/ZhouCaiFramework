using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    public class TagController : AdminBaseController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService, ILogger<TagController> logger)
            : base(logger)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagCreateDto dto)
        {
            var tag = new Tag
            {
                Name = dto.Name,
                Color = dto.Color
            };

            var result = await _tagService.Create(tag);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TagUpdateDto dto)
        {
            var tag = await _tagService.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }

            tag.Name = dto.Name;
            tag.Color = dto.Color;

            var success = await _tagService.Update(tag);
            return success ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] bool confirm)
        {
            var success = await _tagService.Delete(id, confirm);
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _tagService.Disable(id);
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/visibility")]
        public async Task<IActionResult> SetVisibility(int id, [FromBody] TagVisibilityDto dto)
        {
            var success = await _tagService.ToggleVisibility(id, dto.IsHidden);
            return success ? Ok() : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tag = await _tagService.GetById(id);
            return tag != null ? Ok(tag) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetAll();
            return Ok(tags);
        }

        [HttpGet("visible")]
        public async Task<IActionResult> GetVisible()
        {
            var tags = await _tagService.GetVisibleTags();
            return Ok(tags);
        }
    }
}