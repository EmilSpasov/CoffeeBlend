namespace CoffeeBlend.Data.Models
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
