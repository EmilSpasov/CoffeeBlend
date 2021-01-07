namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;

    public interface IImageService
    {
        Task CreateImageAsync(string imageUrl);

        Image GetImageByUrl(string imageUrl);
    }
}
