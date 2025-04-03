using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class AddProjectViewModel
{
    [DataType(DataType.ImageUrl)]
    public string? Image { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Project Name", Prompt = "Enter a project name")]
    [DataType(DataType.Text)]
    public string ProjectName { get; set; } = null!;

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Client Name", Prompt = "Enter client name")]
    [DataType(DataType.Text)]
    public string CLientName { get; set; } = null!;

    [Display(Name = "Description", Prompt = "Write a short description (optional)")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Start Date", Prompt = "Please select a start date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date", Prompt = "Select an end date (optional)")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Members", Prompt = "Add members to the project")]
    [DataType(DataType.Text)]
    public string Members { get; set; } = null!;

    [Display(Name = "Budget", Prompt = "0")]
    [DataType(DataType.Currency)]
    public decimal? Budget { get; set; }

    public string ClientId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public int StatusId { get; set; }
}
