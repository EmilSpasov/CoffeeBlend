namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly ICloudinaryService cloudinaryService;

        public ProductService(IDeletableEntityRepository<Product> productsRepository, IDeletableEntityRepository<Image> imageRepository, ICloudinaryService cloudinaryService)
        {
            this.productsRepository = productsRepository;
            this.imageRepository = imageRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(CreateProductInputModel input)
        {
            var uploadedImage = this.cloudinaryService.UploadAsync(input.ImageFile);
            var imageUrl = uploadedImage.Result;

            var image = new Image
            {
                Url = imageUrl,
            };

            var product = new Product
            {
                Name = input.Name,
                Image = image,
                Description = input.Description,
                Price = input.Price,
                CategoryProductId = input.CategoryProductId,
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }
    }
}
