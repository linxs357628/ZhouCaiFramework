using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 系统设置
    /// </summary>

    public class SystemSettingsController : AdminBaseController
    {
        public SystemSettingsController(ISqlSugarClient db, ILogger<AdminBaseController> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// 获取所有员工账号
        /// </summary>
        /// <returns></returns>
        [HttpGet("employee-accounts")]
        public IActionResult GetEmployeeAccounts()
        {
            // TODO: Implement employee account management
            return Ok(new[] { new { Id = 1, Username = "admin1" } });
        }

        /// <summary>
        /// 添加员工账号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add-employee")]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest request)
        {
            // TODO: Implement add employee
            return Ok(new { Success = true, Message = "Employee added" });
        }
    }
}