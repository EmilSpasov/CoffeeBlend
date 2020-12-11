namespace CoffeeBlend.Web.ViewModels.ReservationViewModel
{
    using System;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime ReservationDate { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
