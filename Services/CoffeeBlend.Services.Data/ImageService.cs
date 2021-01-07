namespace CoffeeBlend.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public ImageService(IDeletableEntityRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task CreateImageAsync(string imageUrl)
        {
            var image = new Image
            {
                Url = imageUrl,
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
        }

        public Image GetImageByUrl(string imageUrl)
        {
            return this.imageRepository
                .All()
                .FirstOrDefault(x => x.Url == imageUrl);
        }
    }
}
