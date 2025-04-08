using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class SignUpViewModel
{
    [Required(ErrorMessage = "is required.")]
    [Display(Name = "First Name", Prompt = "Enter your first name")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Last Name", Prompt = "Enter your last name")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email")]
    [Display(Name = "Email", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "is required.")]
    [Compare(nameof(Password))]
    [Display(Name = "Confirm Password", Prompt = "Confirm your password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [Range(typeof(bool), "true", "true")]
    public bool TermsAndConditions { get; set; }
}
