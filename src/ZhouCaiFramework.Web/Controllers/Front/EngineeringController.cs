using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Front
{
    /// <summary>
    /// ������Ŀ
    /// </summary>
    [ApiController]
    [Route("api/front/[controller]")]
    public class EngineeringController : FrontBaseController
    {
        public EngineeringController(ISqlSugarClient db, ILogger<FrontBaseController> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// ��ȡ���ڽ��еĹ�����Ŀ
        /// </summary>
        /// <returns></returns>
        [HttpGet("ongoing/formwork")]
        public IActionResult GetOngoingFormworkProjects()
        {
            // TODO: Implement formwork projects
            return Ok(new[] { new { Id = 1, ProjectName = "Formwork Project 1" } });
        }

        /// <summary>
        /// ��ȡ���ڽ��еĽ��ּ���Ŀ
        /// </summary>
        /// <returns></returns>
        [HttpGet("ongoing/scaffolding")]
        public IActionResult GetOngoingScaffoldingProjects()
        {
            // TODO: Implement scaffolding projects
            return Ok(new[] { new { Id = 1, ProjectName = "Scaffolding Project 1" } });
        }

        // Add other engineering endpoints as needed
    }
}