namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;

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

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
           return this.categoriesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList()
                .Select(x => new KeyValuePair<string,string>(x.Id.ToString(), x.Name));
        }
    }
}
