namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.BlogViewModel;

    public interface IBlogService
    {
        Task CreateAsync(CreateBlogInputModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        int GetCount();
    }
}
