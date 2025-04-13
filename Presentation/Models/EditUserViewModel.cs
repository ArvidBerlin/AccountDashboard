using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class EditUserViewModel
{
    [Required]
    public string Id { get; set; } = null!;

    [DataType(DataType.Upload)]
    [Display(Name = "Member Image", Prompt = "Select member image")]
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter first name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter last name")]
    public string LastName { get; set; } = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Enter phone number")]
    public string PhoneNumber { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Job Title", Prompt = "Enter job title")]
    public string JobTitle { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Address", Prompt = "Enter address")]
    public string Address { get; set; } = null!;

    [DataType(DataType.Date)]
    [Display(Name = "Birth Date", Prompt = "Enter birth date")]
    public string BirthDate { get; set; } = null!;
}
