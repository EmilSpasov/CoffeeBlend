namespace CoffeeBlend.Web.ViewComponents
{
    using System.Threading.Tasks;

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

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productId)
        {
            var viewModel = new RelatedProductsViewModel
            {
                Products = await this.productService.GetRelatedProductsByCategoryIdAsync<SingleProductViewModel>(categoryId, productId),
            };

            return this.View(viewModel);
        }
    }
}
