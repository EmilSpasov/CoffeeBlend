namespace CoffeeBlend.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
