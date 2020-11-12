using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoffeeBlend.Data.Common.Models;

namespace CoffeeBlend.Data.Models
{
    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal TotalPrice { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
