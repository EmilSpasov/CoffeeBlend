namespace CoffeeBlend.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BuyedCount { get; set; }

        public int CategoryProductId { get; set; }

        public virtual CategoryProduct CategoryProduct { get; set; }
    }
}
