namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Data.Models.Enums;
    using CoffeeBlend.Services.Mapping;

    public class SingleProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal ActualPrice => this.Price;

        public PortionSize PortionSize { get; set; }

        public int Quantity => 1;

        public string Request { get; set; }

        public int CategoryId { get; set; }
    }
}
