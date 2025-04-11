using Microsoft.AspNetCore.Http;

namespace Business.Models;

public class AddUserFormData
{
    public IFormFile? Image { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? JobTitle { get; set; }
    public string? Address { get; set; }
    public DateOnly? BirthDate { get; set; }
}
