using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class NotificationTargetRepository(AppDbContext context) : BaseRepository<NotificationTargetEntity, Notification>(context)
{

}
