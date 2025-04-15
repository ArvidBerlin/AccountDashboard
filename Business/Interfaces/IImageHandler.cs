using Microsoft.AspNetCore.Http;

namespace Business.Interfaces;

public interface IImageHandler
{
    Task<string?> SaveProjectImageAsync(IFormFile file);
}