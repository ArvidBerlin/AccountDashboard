using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class EditUserFormData
{
    public string Id { get; set; } = null!;
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string JobTitle { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
}
