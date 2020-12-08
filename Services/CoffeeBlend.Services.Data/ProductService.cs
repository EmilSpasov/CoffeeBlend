namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<CategoryProduct> categoryRepository;

        public ProductService(
            IDeletableEntityRepository<Product> productsRepository,
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
                Name = input.Name.ToUpper(),
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

        public async Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage)
        {
            var products = await this.productsRepository
                .AllAsNoTrackingWithDeleted()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

            return products;

            //var blogs = this.articleRepository.AllAsNoTracking()
            //    .OrderByDescending(x => x.Id)
            //    .Skip((page - 1) * itemsPerPage)
            //    .Take(itemsPerPage)
            //    .To<T>()
            //    .ToList();

            //return blogs;

            // 1-6 - page 1
            // 7-12 - page 2
            // 13-18 - page 3
        }

        public async Task<IEnumerable<T>> GetAllByCategoryNameAsync<T>(string name)
        {
            var currentCategory = await this.categoryRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

            var categoryId = currentCategory.Id;

            var products = await this.productsRepository.AllAsNoTracking()
                .Where(x => x.CategoryProductId == categoryId)
                .To<T>()
                .ToListAsync();

            return products;
        }

        public async Task<T> GetSingleProductByIdAsync<T>(int id)
        {
            var product = await this.productsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<T>> GetRelatedProductsByCategoryIdAsync<T>(int categoryId, int productId)
        {
            var relatedProducts = await this.productsRepository
                .AllAsNoTracking()
                .Where(x => x.CategoryProductId == categoryId && x.Id != productId)
                .To<T>()
                .Take(4)
                .ToArrayAsync();

            return relatedProducts;
        }

        public int GetCount()
        {
            return this.productsRepository.AllAsNoTrackingWithDeleted().Count();
        }
    }
}
