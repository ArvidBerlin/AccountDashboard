using Data.Entities;

namespace Data.Interfaces;

public interface INotificationRepository : IBaseRepository<NotificationEntity, Notification>
{
    Task<NotificationResult<Notification>> GetLatestNotification();
}