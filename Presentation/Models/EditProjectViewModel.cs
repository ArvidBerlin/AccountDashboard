using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class EditProjectViewModel
{
    [DataType(DataType.ImageUrl)]
    public string? Image { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Project Name", Prompt = "Edit project name")]
    [DataType(DataType.Text)]
    public string ProjectName { get; set; } = null!;

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Client Name", Prompt = "Edit client name")]
    [DataType(DataType.Text)]
    public string ClientName { get; set; } = null!;

    [Display(Name = "Description", Prompt = "Edit description")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Start Date", Prompt = "Change start date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date", Prompt = "Change end date")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [Required]
    [Display(Name = "Members", Prompt = "Edit project memmbers")]
    [DataType(DataType.Text)]
    public string Members { get; set; } = null!;

    [Display(Name = "Budget", Prompt = "0")]
    [DataType(DataType.Currency)]
    public decimal? Budget { get; set; }

    public string ClientId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public int StatusId { get; set; }
}
