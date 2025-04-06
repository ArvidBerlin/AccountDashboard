﻿using Business.Models;
using Domain.Models;

namespace Business.Interfaces;

public interface IUserService
{
    Task<UserResult> AddUserToRoleAsync(string userId, string roleName);
    Task<UserResult> CreateUserAsync(SignUpFormData formData, string roleName = "User");
    Task<string> GetDisplayName(string userId);
    Task<UserResult> GetUsersAsync();
    Task<UserResult> UserExistsByEmailAsync(string email);
}