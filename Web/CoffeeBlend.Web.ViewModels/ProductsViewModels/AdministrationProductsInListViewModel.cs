namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using System.Collections.Generic;

    public class AdministrationProductsInListViewModel : PagingViewModel
    {
        public IEnumerable<AdministrationProductsViewModel> Products { get; set; }
    }
}
