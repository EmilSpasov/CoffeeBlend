namespace CoffeeBlend.Web.ViewModels.OrderViewModel
{
    using System.Collections.Generic;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class CartViewModel : IMapFrom<Cart>
    {
        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public IEnumerable<CartProductsViewModel> CartProducts { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Cart, CartViewModel>()
        //        .ForMember(c => c.CartProducts, otp =>
        //            otp.MapFrom(x => x.CartProducts));
        //}
    }
}
