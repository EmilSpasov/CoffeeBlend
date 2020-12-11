namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ReservationViewModel;

    public interface IReservationService
    {
        Task CreateAsync(CreateReservationInputModel input);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task UpdateAsync(ReservationViewModel input);

        Task DeleteByIdAsync(int id);
    }
}
