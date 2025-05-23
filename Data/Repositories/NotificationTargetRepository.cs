﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Domain.Models;

namespace Data.Repositories;

public class NotificationTargetRepository(AppDbContext context) : BaseRepository<NotificationTargetEntity, Notification>(context), INotificationTargetRepository
{

}
