namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.OrderViewModel;

    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, CreatePaymentInputModel input);
    }
}
