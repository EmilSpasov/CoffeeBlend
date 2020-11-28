namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<CategoryProduct> categoryRepository;

        public ProductService(IDeletableEntityRepository<Product> productsRepository,
            IDeletableEntityRepository<Image> imageRepository,
            ICloudinaryService cloudinaryService,
            IDeletableEntityRepository<CategoryProduct> categoryRepository)
        {
            this.productsRepository = productsRepository;
            this.imageRepository = imageRepository;
            this.cloudinaryService = cloudinaryService;
            this.categoryRepository = categoryRepository;
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

        public IEnumerable<T> GetAllByCategoryName<T>(string name)
        {
            string categoryName = name;

            if (categoryName == "Menu")
            {
                categoryName = "Coffee";
            }

            var currentCategory = this.categoryRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == categoryName);

            var categoryId = currentCategory.Id;

            var products = this.productsRepository.AllAsNoTracking()
                .Where(x => x.CategoryProductId == categoryId)
                .To<T>()
                .ToList();

            return products;
        }

        public T GetSingleProductById<T>(int id)
        {
            var product = this.productsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return product;
        }
    }
}
