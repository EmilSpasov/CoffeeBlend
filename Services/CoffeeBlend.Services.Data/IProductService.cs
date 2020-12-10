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

        Task<T> GetProductByIdWithDeletedAsync<T>(int id);

        Task<IEnumerable<T>> GetRelatedProductsByCategoryIdAsync<T>(int categoryId, int productId);

        Task UpdateAsync(AdministrationProductsViewModel product);

        Task DeleteByIdAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        int GetCount();
    }
}
