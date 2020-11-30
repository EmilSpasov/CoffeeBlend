namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Data.Models.Enums;
    using CoffeeBlend.Services.Mapping;

    public class SingleProductViewModel : IMapFrom<Product>
    {
        private const decimal MediumPrice = 1.40m;
        private const decimal LargePrice = 1.90m;

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal ActualPrice => this.Price;

        public PortionSize PortionSize { get; set; }

        public int Quantity { get; set; } = 1;

        public string Request { get; set; }

        public decimal MediumSizePrice => MediumPrice;

        public decimal LargeSizePrice => LargePrice;
    }
}
