namespace CoffeeBlend.Web.ViewModels.CategoriesViewModel
{
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class CategoryViewModel : IMapFrom<CategoryProduct>
    {
        // TODO:
        public string Name { get; set; }
    }
}
