using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Infrastructure.Image.Abstraction;
using Infrastructure.Image.Configuration;
using Meama.Common.Upload.Files.Interfaces;

namespace Infrastructure.Image.Implementation;

public class ImageUploadService : IImageUploadService
{
    private readonly IImagesUpload _imagesUpload;
    private readonly IOptions<BlobInfoOption> _azureBlobStorageInfo;

    public ImageUploadService(IImagesUpload imagesUpload, IOptions<BlobInfoOption> azureBlobStorageInfo)
    {
        _imagesUpload = imagesUpload;
        _azureBlobStorageInfo = azureBlobStorageInfo;
    }

    public async Task RemoveImagesAsync(List<string> imageUrlsToRemove)
    {
        foreach (var image in imageUrlsToRemove ?? Enumerable.Empty<string>())
        {
            if (!string.IsNullOrEmpty(image))
            {
                await _imagesUpload.DeleteImageFromAzureBlobAsync(image);
            }
        }
    }

    public async Task RemoveImageAsync(string imageUrlToRemove)
    {
        if (!string.IsNullOrEmpty(imageUrlToRemove))
        {
            await _imagesUpload.DeleteImageFromAzureBlobAsync(imageUrlToRemove);
        }
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        if (image is not null)
        {
            var imageUrl = await _imagesUpload.UploadImageTinyPngToAzureBlobAsync(image, _azureBlobStorageInfo.Value.AzureBlobStorageContainerName);

            return imageUrl;
        }

        return null;
    }
}