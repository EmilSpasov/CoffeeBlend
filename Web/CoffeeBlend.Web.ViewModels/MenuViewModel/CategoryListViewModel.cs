namespace CoffeeBlend.Web.ViewModels.MenuViewModel
{
    using System.Collections.Generic;

    public class CategoryListViewModel
    {
        public IEnumerable<CategoryInListViewModel> Categories { get; set; }
    }
}
