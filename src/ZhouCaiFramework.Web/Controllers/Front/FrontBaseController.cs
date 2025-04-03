using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ZhouCaiFramework.Web.Controllers.Front
{
    [ApiController]
    [Route("api/front/[controller]")]
    [Authorize]
    public class FrontBaseController : BaseController
    {
        public FrontBaseController()
        {
        }

        public FrontBaseController(ILogger<FrontBaseController> logger) : base(logger)
        {
        }

        public FrontBaseController(ISqlSugarClient db) : base(db)
        {
        }

        public FrontBaseController(ISqlSugarClient db, ILogger<FrontBaseController> logger) : base(db, logger)
        {
        }
    }
}