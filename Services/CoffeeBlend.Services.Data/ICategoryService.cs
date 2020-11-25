namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel input);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllByName<T>(string name);

        IEnumerable<T> GetAllById<T>(int id);
    }
}
