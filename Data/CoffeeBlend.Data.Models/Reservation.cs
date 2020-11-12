namespace CoffeeBlend.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Reservation : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public DateTime ReservationDate { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        public string Message { get; set; }
    }
}
