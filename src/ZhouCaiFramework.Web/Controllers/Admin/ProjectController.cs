using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class ProjectController : AdminBaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(
            IProjectService projectService,
            ILogger<ProjectController> logger) : base(null, logger)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectService.GetProject(id);
            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects([FromQuery] ProjectQuery query)
        {
            var result = await _projectService.GetProjects(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectCreateDto dto)
        {
            var id = await _projectService.CreateProject(dto);
            return CreatedAtAction(nameof(GetProject), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto dto)
        {
            dto.Id = id;
            var result = await _projectService.UpdateProject(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProject(id);
            return Ok(result);
        }

        [HttpPost("{projectId}/entry")]
        public async Task<IActionResult> AddEntryRecord(int projectId, [FromBody] ProjectOperationDto dto)
        {
            var result = await _projectService.AddEntryRecord(projectId, dto);
            return Ok(result);
        }

        [HttpPost("{projectId}/withdrawal")]
        public async Task<IActionResult> AddWithdrawalRecord(int projectId, [FromBody] ProjectOperationDto dto)
        {
            var result = await _projectService.AddWithdrawalRecord(projectId, dto);
            return Ok(result);
        }

        [HttpPost("{projectId}/inventory")]
        public async Task<IActionResult> AddInventoryRecord(int projectId, [FromBody] ProjectOperationDto dto)
        {
            var result = await _projectService.AddInventoryRecord(projectId, dto);
            return Ok(result);
        }

        [HttpPost("{projectId}/suspension")]
        public async Task<IActionResult> AddSuspensionRecord(int projectId, [FromBody] ProjectOperationDto dto)
        {
            var result = await _projectService.AddSuspensionRecord(projectId, dto);
            return Ok(result);
        }

        [HttpPut("{projectId}/progress")]
        public async Task<IActionResult> UpdateProgressQuantity(int projectId, [FromBody] string quantity)
        {
            var result = await _projectService.UpdateProgressQuantity(projectId, quantity);
            return Ok(result);
        }

        [HttpPut("{projectId}/payment")]
        public async Task<IActionResult> UpdatePaymentStatus(int projectId, [FromBody] PaymentUpdateDto dto)
        {
            var result = await _projectService.UpdatePaymentStatus(projectId, dto);
            return Ok(result);
        }
    }
}