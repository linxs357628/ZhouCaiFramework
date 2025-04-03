using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ZhouCaiFramework.Model;

namespace ZhouCaiFramework.Web.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly ISqlSugarClient _db;
        public readonly ILogger<BaseController> _logger;

        public BaseController()
        {
        }

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        public BaseController(ISqlSugarClient db)
        {
            _db = db;
        }

        public BaseController(ISqlSugarClient db, ILogger<BaseController> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// 返回成功结果
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回的数据</param>
        /// <param name="message">返回的消息</param>
        /// <returns>IActionResult</returns>
        protected IActionResult Success<T>(T data, string message = "操作成功")
        {
            LogInfo($"操作成功，消息: {message}");
            return Ok(new ApiResponse<T>(200, message, data));
        }

        /// <summary>
        /// 返回失败结果
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="message">返回的消息</param>
        /// <param name="code">状态码，默认 500</param>
        /// <returns>IActionResult</returns>
        protected IActionResult Fail<T>(string message = "操作失败", int code = 500)
        {
            LogError($"操作失败，状态码: {code}，消息: {message}");
            return StatusCode(code, new ApiResponse<T>(code, message, default(T)));
        }

        /// <summary>
        /// 返回 400 错误结果（客户端请求错误）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="message">返回的消息</param>
        /// <returns>IActionResult</returns>
        protected IActionResult BadRequest<T>(string message = "客户端请求错误")
        {
            LogError($"客户端请求错误，消息: {message}");
            return StatusCode(400, new ApiResponse<T>(400, message, default(T)));
        }

        /// <summary>
        /// 返回 401 错误结果（未授权）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="message">返回的消息</param>
        /// <returns>IActionResult</returns>
        protected IActionResult Unauthorized<T>(string message = "未授权访问")
        {
            LogError($"未授权访问，消息: {message}");
            return StatusCode(401, new ApiResponse<T>(401, message, default(T)));
        }

        /// <summary>
        /// 返回 403 错误结果（禁止访问）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="message">返回的消息</param>
        /// <returns>IActionResult</returns>
        protected IActionResult Forbidden<T>(string message = "禁止访问")
        {
            LogError($"禁止访问，消息: {message}");
            return StatusCode(403, new ApiResponse<T>(403, message, default(T)));
        }

        /// <summary>
        /// 返回 404 错误结果（资源未找到）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="message">返回的消息</param>
        /// <returns>IActionResult</returns>
        protected IActionResult NotFound<T>(string message = "资源未找到")
        {
            LogError($"资源未找到，消息: {message}");
            return StatusCode(404, new ApiResponse<T>(404, message, default(T)));
        }

        /// <summary>
        /// 记录信息日志
        /// </summary>
        /// <param name="message">日志消息</param>
        private void LogInfo(string message)
        {
            _logger?.LogInformation(message);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message">日志消息</param>
        private void LogError(string message)
        {
            _logger?.LogError(message);
        }
    }
}