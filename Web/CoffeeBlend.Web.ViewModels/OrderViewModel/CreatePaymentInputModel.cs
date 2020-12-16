namespace CoffeeBlend.Web.ViewModels.OrderViewModel
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Models;

    public class CreatePaymentInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Country { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Town { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [RegularExpression("(^\\+[0-9]{2}|^\\+[0-9]{2}\\(0\\)|^\\(\\+[0-9]{2}\\)\\(0\\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\\-\\s]{10}$)", ErrorMessage = "Please enter a valid phone")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
