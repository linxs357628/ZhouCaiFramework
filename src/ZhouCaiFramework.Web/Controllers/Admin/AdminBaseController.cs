using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize]
    public class AdminBaseController : ControllerBase
    {
        public readonly ISqlSugarClient _db;
        public readonly ILogger<AdminBaseController> _logger;

        public AdminBaseController(ISqlSugarClient db, ILogger<AdminBaseController> logger)
        {
            _db = db;
            _logger = logger;
        }
    }
}