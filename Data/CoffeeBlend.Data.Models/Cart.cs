namespace CoffeeBlend.Data.Models
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        public Cart()
        {
            this.CartProducts = new HashSet<CartProduct>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
