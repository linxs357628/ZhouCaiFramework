using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 员工管理
    /// </summary>

    public class EmployeeController : AdminBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
            : base(logger)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// 创建员工
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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
            return Success(result);
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
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
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 启用、禁用员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _employeeService.DisableEmployee(id);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _employeeService.DeleteEmployee(id);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 给员工分配角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}/role")]
        public async Task<IActionResult> AssignRole(int id, [FromBody] RoleAssignDto dto)
        {
            var success = await _employeeService.AssignRole(id, dto.Role);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return employee != null ? Success(employee) : NotFound();
        }

        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var employees = await _employeeService.GetEmployees(page, size);
            return Success(employees);
        }

        /// <summary>
        /// 搜索员工
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var employees = await _employeeService.SearchEmployees(keyword);
            return Success(employees);
        }
    }
}