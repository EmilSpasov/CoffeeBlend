namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using System.Collections.Generic;

    public class RelatedProductsViewModel
    {
        public IEnumerable<SingleProductViewModel> Products { get; set; }
    }
}
