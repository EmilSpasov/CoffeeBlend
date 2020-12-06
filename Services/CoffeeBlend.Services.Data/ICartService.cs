namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface ICartService
    {
        Task AddAsync(string userId, SingleProductViewModel model);

        T GetCurrentUserCart<T>(string userId);

        Task RemoveProductByIdAsync(string userId, int id);

        int GetProductsCount(string userId);
    }
}
