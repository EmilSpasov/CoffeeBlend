namespace CoffeeBlend.Web.ViewModels.OrderViewModel
{
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public class CartViewModel : SingleProductViewModel
    {
        public decimal SubTotalPrice { get; set; }

        public decimal DeliveryPrice => this.SubTotalPrice < 30 ? 5 : 0;

        public decimal TotalPrice => this.SubTotalPrice + this.DeliveryPrice;
    }
}
