using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface INotificationService
    {
        Task<Notification> CreateDraft(Notification notification);

        Task<bool> Publish(int notificationId);

        Task<bool> Update(Notification notification);

        Task<bool> Delete(int notificationId);

        Task<Notification> GetById(int notificationId);

        Task<IEnumerable<Notification>> GetDrafts();

        Task<IEnumerable<Notification>> GetPublished();

        Task<IEnumerable<string>> GetAvailableMerchantTypes();

        Task<bool> ValidateEnterpriseName(string enterpriseName);
    }
}