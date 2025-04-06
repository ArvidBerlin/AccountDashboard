namespace Business.Services;

public class NotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly INotificationTypeRepository _notificationTypeRepository;
    private readonly INotificationTargetRepository _notificationTargetRepository;
    private readonly IUserDismissedNotificationRepository _userDismissedNotificationRepository;
    private readonly IHubContext<NotificationHub> _notificationHub;
}
