namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<CategoryProduct> categoriesRepository;

        public CategoryService(IDeletableEntityRepository<CategoryProduct> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task CreateAsync(CreateCategoryInputModel input)
        {
            var category = new CategoryProduct
            {
                Name = input.Name,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        // Visualize dropdown on create
        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
           return this.categoriesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .OrderBy(x => x.Value);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return await this.categoriesRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithDeletedAsync<T>()
        {
            return await this.categoriesRepository
                .AllAsNoTrackingWithDeleted()
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByNameAsync<T>(string name)
        {
            return await this.categoriesRepository
                .AllAsNoTracking()
                .Where(x => x.Name == name)
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.categoriesRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(AdministrationCategoryViewModel category)
        {
            var categoryToUpdate = this.categoriesRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefault(x => x.Id == category.Id);

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.CreatedOn = category.CreatedOn;
            categoryToUpdate.DeletedOn = category.DeletedOn;
            categoryToUpdate.IsDeleted = category.IsDeleted;
            categoryToUpdate.ModifiedOn = category.ModifiedOn;

            this.categoriesRepository.Update(categoryToUpdate);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var categoryToDelete = await this.categoriesRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.categoriesRepository.Delete(categoryToDelete);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public bool DoesCategoryExists(int id)
        {
            var category = this.categoriesRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefault(x => x.Id == id);

            return category != null;
        }
    }
}
