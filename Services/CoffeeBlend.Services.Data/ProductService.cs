namespace CoffeeBlend.Services.Data
{
    using System;
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

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sortBy, int pageNumber, int itemsPerPage)
        {
            //var products = await this.productsRepository
            //    .AllAsNoTrackingWithDeleted()
            //    .OrderByDescending(x => x.CreatedOn)
            //    .Skip((page - 1) * itemsPerPage)
            //    .Take(itemsPerPage)
            //    .To<T>()
            //    .ToListAsync();

            var products = new List<T>();

            products = sortBy switch
            {
                "name_desc" => await this.productsRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderByDescending(x => x.Name)
                                      .Skip((pageNumber - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "name_asc" => await this.productsRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderBy(x => x.Name)
                                      .Skip((pageNumber - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "price_desc" => await this.productsRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderByDescending(x => x.Price)
                                      .Skip((pageNumber - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "price_asc" => await this.productsRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderBy(x => x.Price)
                                      .Skip((pageNumber - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "category_desc" => await this.productsRepository
                    .AllAsNoTrackingWithDeleted()
                    .OrderByDescending(x => x.CategoryProduct.Name)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync(),
                "category_asc" => await this.productsRepository
                    .AllAsNoTrackingWithDeleted()
                    .OrderBy(x => x.CategoryProduct.Name)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync(),
                "createdOn_desc" => await this.productsRepository
                    .AllAsNoTrackingWithDeleted()
                    .OrderByDescending(x => x.CreatedOn)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync(),
                "createdOn_asc" => await this.productsRepository
                    .AllAsNoTrackingWithDeleted()
                    .OrderBy(x => x.CreatedOn)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync(),
                _ => await this.productsRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderByDescending(x => x.CreatedOn)
                                      .Skip((pageNumber - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
            };
            return products;
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
            var product = await this.productsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<T> GetProductByIdWithDeletedAsync<T>(int id)
        {
            return await this.productsRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetRelatedProductsByCategoryIdAsync<T>(int categoryId, int productId)
        {
            var relatedProducts = await this.productsRepository
                .AllAsNoTracking()
                .Where(x => x.CategoryProductId == categoryId && x.Id != productId)
                .OrderBy(x => Guid.NewGuid())
                .To<T>()
                .Take(4)
                .ToArrayAsync();

            return relatedProducts;
        }

        public async Task<IEnumerable<T>> GetMostBuyedProductsAsync<T>()
        {
            return await this.productsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.BuyedCount)
                .To<T>()
                .Take(4)
                .ToListAsync();
        }

        public async Task UpdateAsync(AdministrationProductsViewModel product)
        {
            var productToUpdate = this.productsRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefault(x => x.Id == product.Id);

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryProductId = product.CategoryProductId;
            productToUpdate.Description = product.Description;
            productToUpdate.DeletedOn = product.DeletedOn;
            productToUpdate.IsDeleted = product.IsDeleted;
            productToUpdate.CreatedOn = product.CreatedOn;
            productToUpdate.ModifiedOn = product.ModifiedOn;

            this.productsRepository.Update(productToUpdate);
            await this.productsRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var productToDelete = await this.productsRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.productsRepository.Delete(productToDelete);
            await this.productsRepository.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.productsRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public int GetCount()
        {
            return this.productsRepository.AllAsNoTrackingWithDeleted().Count();
        }
    }
}
