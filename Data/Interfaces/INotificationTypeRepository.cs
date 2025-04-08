using Data.Entities;
using Domain.Models;

namespace Data.Interfaces;

public interface INotificationTypeRepository : IBaseRepository<NotificationTypeEntity, Notification>
{
}
