using Microsoft.AspNetCore.Http;

namespace Business.Interfaces;

public interface IAzureImageHandler
{
    Task<string?> SaveProjectImageAsync(IFormFile file);
}