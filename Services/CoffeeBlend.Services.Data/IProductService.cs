namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface IProductService
    {
        Task CreateAsync(CreateProductInputModel input);

        Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 6);

        Task<IEnumerable<T>> GetAllByCategoryNameAsync<T>(string name);

        Task<T> GetSingleProductByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetRelatedProductsByCategoryIdAsync<T>(int categoryId, int productId);

        int GetCount();
    }
}
