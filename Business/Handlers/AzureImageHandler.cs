using Azure.Storage.Blobs;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Business.Handlers;

public class AzureImageHandler : IAzureImageHandler
{
    private readonly BlobContainerClient _containerClient;
    private readonly IConfiguration _configuration;

    public AzureImageHandler(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionString = _configuration["AzureStorageAccount:ConnectionString"];
        var containerName = _configuration["AzureStorageAccount:ContainerName"];

        _containerClient = new BlobContainerClient(connectionString, containerName);
        _containerClient.CreateIfNotExists();
    }

    public async Task<string?> SaveProjectImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null!;

        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid()}{extension}";

        var blobClient = _containerClient.GetBlobClient(fileName);

        await using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, overwrite: true);

        return fileName;
    }
}

