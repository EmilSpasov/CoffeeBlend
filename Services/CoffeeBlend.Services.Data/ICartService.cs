namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface ICartService
    {
        Task AddAsync(string userId, SingleProductViewModel model);
    }
}
