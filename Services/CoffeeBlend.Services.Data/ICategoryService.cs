namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel input);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByNameAsync<T>(string name);

        Task<T> GetByIdAsync<T>(int? id);

        Task UpdateAsync(AdministrationCategoryViewModel category);

        Task DeleteByIdAsync(int id);

        bool DoesCategoryExists(int id);
    }
}
