namespace Presentation.Models;

public class UserViewModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserImage { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string JobTitle { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Message { get; set; } = null!;
}
