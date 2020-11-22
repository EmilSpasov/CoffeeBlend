namespace CoffeeBlend.Web.ViewModels.MenuViewModel
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class MenuViewModel : IMapFrom<CategoryProduct>
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
