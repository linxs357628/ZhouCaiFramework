using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Front
{
    [ApiController]
    [Route("api/front/[controller]")]
    [Authorize]
    public class FrontBaseController : ControllerBase
    {
        public readonly ISqlSugarClient _db;
        public readonly ILogger<FrontBaseController> _logger;

        public FrontBaseController(ISqlSugarClient db, ILogger<FrontBaseController> logger)
        {
            _db = db;
            _logger = logger;
        }
    }
}