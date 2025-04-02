using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<NotificationService> _logger;
        private readonly ITagService _tagService;

        public NotificationService(
            ISqlSugarClient db,
            ILogger<NotificationService> logger,
            ITagService tagService)
        {
            _db = db;
            _logger = logger;
            _tagService = tagService;
        }

        public async Task<Notification> CreateDraft(Notification notification)
        {
            try
            {
                notification.Status = 0; // 草稿状态
                notification.CreateTime = DateTime.Now;
                return await _db.Insertable(notification).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建通知草稿失败");
                throw;
            }
        }

        public async Task<bool> Publish(int notificationId)
        {
            return await _db.Updateable<Notification>()
                .SetColumns(x => new Notification
                {
                    Status = 1,
                    PublishTime = DateTime.Now
                })
                .Where(x => x.Id == notificationId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(Notification notification)
        {
            return await _db.Updateable(notification)
                .IgnoreColumns(x => new { x.Status, x.CreateTime, x.PublishTime })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Delete(int notificationId)
        {
            return await _db.Deleteable<Notification>()
                .Where(x => x.Id == notificationId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<Notification> GetById(int notificationId)
        {
            return await _db.Queryable<Notification>()
                .Where(x => x.Id == notificationId)
                .FirstAsync();
        }

        public async Task<IEnumerable<Notification>> GetDrafts()
        {
            return await _db.Queryable<Notification>()
                .Where(x => x.Status == 0)
                .OrderBy(x => x.CreateTime, OrderByType.Desc)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetPublished()
        {
            return await _db.Queryable<Notification>()
                .Where(x => x.Status == 1)
                .OrderBy(x => x.PublishTime, OrderByType.Desc)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAvailableMerchantTypes()
        {
            var tags = await _tagService.GetAll();
            return tags.Select(x => x.EnterpriseType).Distinct();
        }

        public async Task<bool> ValidateEnterpriseName(string enterpriseName)
        {
            // 检查是否为共享仓企业名称
            var isSharedStorage = await _db.Queryable<Enterprise>()
                .AnyAsync(x => x.Name == enterpriseName && x.IsSharedStorage);

            return !isSharedStorage;
        }
    }
}