using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Domain.Models;

namespace Data.Repositories;
public class NotificationTypeRepository(AppDbContext context) : BaseRepository<NotificationTypeEntity, Notification>(context), INotificationTypeRepository
{
}
