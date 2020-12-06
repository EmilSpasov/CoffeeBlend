namespace CoffeeBlend.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.ReservationViewModel;

    public class ReservationService : IReservationService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;

        public ReservationService(IDeletableEntityRepository<Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public async Task CreateAsync(CreateReservationInputModel input)
        {
            var date = input.Date.Date;

            var time = input.Time.TimeOfDay;

            var reservationDate = date + time;

            var reservation = new Reservation
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                ReservationDate = reservationDate,
                Phone = input.Phone,
                Message = input.Message,
            };

            await this.reservationRepository.AddAsync(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }
    }
}
