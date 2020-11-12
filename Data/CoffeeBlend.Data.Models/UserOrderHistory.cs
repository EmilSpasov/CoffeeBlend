namespace CoffeeBlend.Data.Models
{
    using CoffeeBlend.Data.Common.Models;

    public class UserOrderHistory : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
