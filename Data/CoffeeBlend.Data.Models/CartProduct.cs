namespace CoffeeBlend.Data.Models
{
    using CoffeeBlend.Data.Common.Models;
    using CoffeeBlend.Data.Models.Enums;

    public class CartProduct : BaseModel<int>
    {
        public string Name { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public int Quantity { get; set; } = 1;

        public PortionSize PortionSize { get; set; }

        public string Request { get; set; }

        public decimal Price { get; set; }

        public decimal SubTotalPrice { get; set; }
    }
}
