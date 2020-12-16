namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using CoffeeBlend.Common;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Data.Models.Enums;
    using CoffeeBlend.Services.Mapping;

    public class SingleProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal ActualPrice => this.Price * this.Quantity;

        public PortionSize PortionSize { get; set; }

        public int Quantity { get; set; } = 1;

        public string Request { get; set; }

        public string CategoryProductName { get; set; }

        public int CategoryProductId { get; set; }

        public decimal MediumSizePrice => GlobalConstants.MediumPrice;

        public decimal LargeSizePrice => GlobalConstants.LargePrice;
    }
}
