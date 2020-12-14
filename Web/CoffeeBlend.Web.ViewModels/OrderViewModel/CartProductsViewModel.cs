namespace CoffeeBlend.Web.ViewModels.OrderViewModel
{
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class CartProductsViewModel : IMapFrom<CartProduct>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public string ProductImageUrl { get; set; }

        public string PortionSize { get; set; }

        public int CartId { get; set; }

        public int Quantity { get; set; } = 1;

        public string Request { get; set; }

        public decimal Price { get; set; }

        public decimal SubTotalPrice { get; set; }
    }
}
