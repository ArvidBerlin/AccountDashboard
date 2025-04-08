using Data.Entities;
using Domain.Models;

namespace Data.Interfaces;

public interface INotificationTargetRepository : IBaseRepository<NotificationTargetEntity, Notification>
{
}
