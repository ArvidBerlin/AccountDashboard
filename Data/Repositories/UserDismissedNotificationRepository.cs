using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Domain.Models;
using Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public interface IUserDismissedNotificationRepository : IBaseRepository<UserDismissedNotificationEntity, Notification>
{
    Task<RepositoryResult<IEnumerable<string>>> GetNotificationIdsAsync(string userId);
}
public class UserDismissedNotificationRepository(AppDbContext context) : BaseRepository<UserDismissedNotificationEntity, Notification>(context), IUserDismissedNotificationRepository
{
    public async Task<RepositoryResult<IEnumerable<string>>> GetNotificationIdsAsync(string userId)
    {
        var ids = await _table.Where(x => x.UserId == userId).Select(x => x.NotificationId).ToListAsync();
        return new RepositoryResult<IEnumerable<string>> { Succeeded = true, StatusCode = 200, Result = ids };
    }
}
