namespace CoffeeBlend.Web.ViewModels.MenuViewModel
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class CategoryInListViewModel : IMapFrom<CategoryProduct>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
