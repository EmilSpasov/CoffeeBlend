namespace CoffeeBlend.Data.Models
{

    using CoffeeBlend.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
