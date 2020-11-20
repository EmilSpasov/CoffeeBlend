namespace CoffeeBlend.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Contact : BaseModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }
    }
}
