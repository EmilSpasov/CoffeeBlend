namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel input);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
