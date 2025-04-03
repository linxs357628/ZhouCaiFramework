using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// AdminBaseController
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class AdminBaseController : BaseController
    {
        public AdminBaseController()
        {
        }

        public AdminBaseController(ILogger<AdminBaseController> logger) : base(logger)
        {
        }

        public AdminBaseController(ISqlSugarClient db) : base(db)
        {
        }

        public AdminBaseController(ISqlSugarClient db, ILogger<AdminBaseController> logger) : base(db, logger)
        {
        }
    }
}