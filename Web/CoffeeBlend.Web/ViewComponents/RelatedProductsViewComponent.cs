namespace CoffeeBlend.Web.ViewComponents
{
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class RelatedProductsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public RelatedProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke(int categoryId, int productId)
        {
            var viewModel = new RelatedProductsViewModel
            {
                Products = this.productService.GetRelatedProductsByCategoryId<SingleProductViewModel>(categoryId, productId),
            };

            return this.View(viewModel);
        }
    }
}
