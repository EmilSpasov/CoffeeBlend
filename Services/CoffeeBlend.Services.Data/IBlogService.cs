namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.BlogViewModel;

    public interface IBlogService
    {
        Task CreateAsync(CreateBlogInputModel input);

        Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 6);

        Task<IEnumerable<T>> GetAllWithDeletedAsync<T>(int page, int itemsPerPage = 6);

        Task<IEnumerable<T>> GetMostRecentAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task AddCommentToBlog(string userId, int id, string message);

        Task UpdateAsync(AdministrationBlogsViewModel model);

        Task DeleteByIdAsync(int id);

        int GetCount();
    }
}
