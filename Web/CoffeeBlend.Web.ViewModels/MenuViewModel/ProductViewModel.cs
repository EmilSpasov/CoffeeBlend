namespace CoffeeBlend.Web.ViewModels.MenuViewModel
{
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryProductId { get; set; }
    }
}
