using Business.Models;
using Domain.Models;
using Domain.Responses;

namespace Business.Interfaces;

public interface IUserService
{
    Task<UserResult> AddUserToRoleAsync(string userId, string roleName);
    Task<UserResult> CreateUserAsync(SignUpFormData formData, string roleName = "User");
    Task<string> GetDisplayName(string userId);
    Task<UserResult<IEnumerable<User>>> GetUsersAsync();
    Task<UserResult<User>> GetUserByIdAsync(string id);
    Task<UserResult> UserExistsByEmailAsync(string email);
    Task<UserResult> CreateMemberAsync(AddUserFormData formData);
}