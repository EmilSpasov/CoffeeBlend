namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ReservationViewModel;

    public interface IReservationService
    {
        Task CreateAsync(CreateReservationInputModel input);
    }
}
