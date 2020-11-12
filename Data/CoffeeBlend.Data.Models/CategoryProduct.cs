namespace CoffeeBlend.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class CategoryProduct : BaseDeletableModel<int>
    {
        public CategoryProduct()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
