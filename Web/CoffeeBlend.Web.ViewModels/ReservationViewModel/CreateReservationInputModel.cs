namespace CoffeeBlend.Web.ViewModels.ReservationViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateReservationInputModel
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public DateTime ReservationDate { get; set; }

        [Required]
        [RegularExpression("(^\\+[0-9]{2}|^\\+[0-9]{2}\\(0\\)|^\\(\\+[0-9]{2}\\)\\(0\\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\\-\\s]{10}$)", ErrorMessage = "Please enter a valid phone")]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Message { get; set; }
    }
}
