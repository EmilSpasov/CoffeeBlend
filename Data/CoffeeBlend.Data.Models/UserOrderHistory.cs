namespace CoffeeBlend.Data.Models
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Common.Models;

    public class UserOrderHistory : BaseDeletableModel<int>
    {
        public UserOrderHistory()
        {
            this.Orders = new HashSet<Order>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
