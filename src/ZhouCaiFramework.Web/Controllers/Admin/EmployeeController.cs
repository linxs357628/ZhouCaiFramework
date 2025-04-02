using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class EmployeeController : AdminBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
            : base(null, logger)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto dto)
        {
            var employee = new Employee
            {
                Username = dto.Username,
                Name = dto.Name,
                Position = dto.Position,
                Role = dto.Role
            };

            var result = await _employeeService.CreateEmployee(employee, dto.Password);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeUpdateDto dto)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = dto.Name;
            employee.Position = dto.Position;
            employee.Role = dto.Role;

            var success = await _employeeService.UpdateEmployee(employee);
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _employeeService.DisableEmployee(id);
            return success ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _employeeService.DeleteEmployee(id);
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/role")]
        public async Task<IActionResult> AssignRole(int id, [FromBody] RoleAssignDto dto)
        {
            var success = await _employeeService.AssignRole(id, dto.Role);
            return success ? Ok() : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return employee != null ? Ok(employee) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var employees = await _employeeService.GetEmployees(page, size);
            return Ok(employees);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var employees = await _employeeService.SearchEmployees(keyword);
            return Ok(employees);
        }
    }
}