namespace CoffeeBlend.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;
    using CoffeeBlend.Data.Models.Enums;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Url { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Range(1, 10)]
        public int Quantity { get; set; }

        public PortionSize PortionSize { get; set; }

        public int BoughtCount{ get; set; }

        public int CategoryProductId { get; set; }

        public virtual CategoryProduct CategoryProduct { get; set; }
    }
}
