namespace CoffeeBlend.Web.ViewModels.OrderViewModel
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public class CartViewModel : IMapFrom<Cart>
    {
        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<SingleProductViewModel> Products { get; set; }
    }
}
