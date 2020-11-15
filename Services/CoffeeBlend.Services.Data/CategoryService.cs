namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<CategoryProduct> categoriesRepository;

        public CategoryService(IDeletableEntityRepository<CategoryProduct> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
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
