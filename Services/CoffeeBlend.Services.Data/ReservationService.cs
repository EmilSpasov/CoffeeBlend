namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.ReservationViewModel;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return await this.reservationRepository
                .AllAsNoTrackingWithDeleted()
                .OrderByDescending(x => x.ReservationDate)
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.reservationRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(ReservationViewModel input)
        {
            var reservationToUpdate = await this.reservationRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == input.Id)
                .FirstOrDefaultAsync();

            reservationToUpdate.FirstName = input.FirstName;
            reservationToUpdate.LastName = input.LastName;
            reservationToUpdate.Message = input.Message;
            reservationToUpdate.Phone = input.Phone;
            reservationToUpdate.ReservationDate = input.ReservationDate;
            reservationToUpdate.DeletedOn = input.DeletedOn;
            reservationToUpdate.ModifiedOn = input.ModifiedOn;
            reservationToUpdate.IsDeleted = input.IsDeleted;
            reservationToUpdate.CreatedOn = input.CreatedOn;

            this.reservationRepository.Update(reservationToUpdate);
            await this.reservationRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var reservationToDelete = await this.reservationRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.reservationRepository.Delete(reservationToDelete);
            await this.reservationRepository.SaveChangesAsync();
        }
    }
}
