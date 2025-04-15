using Business.Interfaces;
using Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController(IHubContext<NotificationHub> notificationHhub, INotificationService notificationService) : ControllerBase
{
    private readonly IHubContext<NotificationHub> _notificationHhub = notificationHhub;
    private readonly INotificationService _notificationService = notificationService;

    //[HttpPost("dismiss/{id}")]
    //public async Task<IActionResult> DismissNotification(string id)
    //{
    //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";
    //    if (string.IsNullOrEmpty(userId))
    //        return Unauthorized();

    //    await _notificationService.DismissNotificationsAsync(id, userId);
    //    return Ok(new { success = true });
    //}
}
