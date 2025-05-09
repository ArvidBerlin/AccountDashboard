﻿using Business.Models;
using Domain.Models;
using Domain.Responses;

namespace Business.Interfaces;

public interface INotificationService
{
    Task<NotificationResult> AddNotificationAsync(NotificationFormData formData);
    Task DismissNotificationsAsync(string notificationId, string userId);
    Task<NotificationResult<IEnumerable<Notification>>> GetNotificationsAsync(string userId, string? roleName = null, int take = 10);
}