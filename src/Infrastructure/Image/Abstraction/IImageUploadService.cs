using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Infrastructure.Image.Abstraction;

public interface IImageUploadService
{
    Task RemoveImageAsync(string imageUrlToRemove);

    Task RemoveImagesAsync(List<string> imageUrlsToRemove);

    Task<string> UploadImageAsync(IFormFile image);
}