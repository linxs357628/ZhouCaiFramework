using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// ���̹���
    /// </summary>

    public class EngineeringController : AdminBaseController
    {
        public EngineeringController(ISqlSugarClient db, ILogger<AdminBaseController> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// ��ȡ���ڽ��еĹ���
        /// </summary>
        /// <returns></returns>
        [HttpGet("ongoing/formwork")]
        public IActionResult GetOngoingFormworkProjects()
        {
            // TODO: Implement formwork projects (admin view)
            return Success(new[] { new { Id = 1, ProjectName = "Admin Formwork Project" } });
        }

        /// <summary>
        /// ��ȡ���ڽ��еĽ��ּܹ���
        /// </summary>
        /// <returns></returns>
        [HttpGet("ongoing/scaffolding")]
        public IActionResult GetOngoingScaffoldingProjects()
        {
            // TODO: Implement scaffolding projects (admin view)
            return Success(new[] { new { Id = 1, ProjectName = "Admin Scaffolding Project" } });
        }
    }
}