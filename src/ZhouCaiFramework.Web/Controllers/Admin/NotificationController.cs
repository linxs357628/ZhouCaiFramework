using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 通知管理
    /// </summary>

    public class NotificationController : AdminBaseController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(
            INotificationService notificationService,
            ILogger<NotificationController> logger)
            : base(logger)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// 创建草稿
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("draft")]
        public async Task<IActionResult> CreateDraft([FromBody] NotificationCreateDto dto)
        {
            var notification = new Notification
            {
                MerchantType = dto.MerchantType,
                Title = dto.Title,
                Content = dto.Content,
                LinkUrl = dto.LinkUrl,
                Platforms = JsonConvert.SerializeObject(dto.Platforms),
                NotificationType = dto.NotificationType,
                DistributionRules = JsonConvert.SerializeObject(dto.DistributionRules),
                Tags = JsonConvert.SerializeObject(dto.Tags),
                Creator = User.Identity.Name
            };

            var result = await _notificationService.CreateDraft(notification);
            return Ok(result);
        }

        /// <summary>
        /// 发布通知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/publish")]
        public async Task<IActionResult> Publish(int id)
        {
            var success = await _notificationService.Publish(id);
            return success ? Ok() : BadRequest();
        }

        /// <summary>
        /// 更新通知
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotificationUpdateDto dto)
        {
            var notification = await _notificationService.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }

            notification.Title = dto.Title;
            notification.Content = dto.Content;
            notification.LinkUrl = dto.LinkUrl;
            notification.Platforms = JsonConvert.SerializeObject(dto.Platforms);
            notification.NotificationType = dto.NotificationType;
            notification.DistributionRules = JsonConvert.SerializeObject(dto.DistributionRules);
            notification.Tags = JsonConvert.SerializeObject(dto.Tags);

            var success = await _notificationService.Update(notification);
            return success ? Ok() : BadRequest();
        }

        /// <summary>
        /// 删除通知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _notificationService.Delete(id);
            return success ? Ok() : BadRequest();
        }

        /// <summary>
        /// 获取通知详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notification = await _notificationService.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }

            var result = new NotificationDetailDto
            {
                Id = notification.Id,
                MerchantType = notification.MerchantType,
                Title = notification.Title,
                Content = notification.Content,
                LinkUrl = notification.LinkUrl,
                Platforms = JsonConvert.DeserializeObject<List<string>>(notification.Platforms),
                NotificationType = notification.NotificationType,
                DistributionRules = JsonConvert.DeserializeObject<Dictionary<string, string>>(notification.DistributionRules),
                Tags = JsonConvert.DeserializeObject<List<int>>(notification.Tags),
                Status = notification.Status,
                CreateTime = notification.CreateTime,
                PublishTime = notification.PublishTime,
                Creator = notification.Creator
            };

            return Ok(result);
        }

        /// <summary>
        /// 获取草稿列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("drafts")]
        public async Task<IActionResult> GetDrafts()
        {
            var drafts = await _notificationService.GetDrafts();
            return Ok(drafts);
        }

        /// <summary>
        /// 获取已发布列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("published")]
        public async Task<IActionResult> GetPublished()
        {
            var published = await _notificationService.GetPublished();
            return Ok(published);
        }

        /// <summary>
        /// 获取可用的商户类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("merchant-types")]
        public async Task<IActionResult> GetMerchantTypes()
        {
            var types = await _notificationService.GetAvailableMerchantTypes();
            return Ok(types);
        }

        /// <summary>
        /// 验证企业名称是否可用
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("validate-enterprise")]
        public async Task<IActionResult> ValidateEnterpriseName([FromQuery] string name)
        {
            var isValid = await _notificationService.ValidateEnterpriseName(name);
            return Ok(new { IsValid = isValid });
        }
    }
}