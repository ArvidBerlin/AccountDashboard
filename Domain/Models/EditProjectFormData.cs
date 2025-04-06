﻿using Microsoft.AspNetCore.Http;

namespace Domain.Models;

public class EditProjectFormData
{
    public string Id { get; set; } = null!;
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }   
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; } // Ska detta vara nullable?
    public DateTime? EndDate { get; set; }
    public decimal? Budget { get; set; }
    public string ClientId { get; set; } = null!;
    public int StatusId { get; set; } // Ska detta vara string?
}
