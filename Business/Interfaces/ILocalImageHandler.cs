using Microsoft.AspNetCore.Http;

namespace Business.Interfaces;

public interface ILocalImageHandler
{
    Task<string?> SaveProjectImageAsync(IFormFile file);
}