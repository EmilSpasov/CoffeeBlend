namespace CoffeeBlend.Web.ViewComponents
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class MostBuyedProductsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public MostBuyedProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new RelatedProductsViewModel
            {
                Products = await this.productService.GetMostBuyedProductsAsync<SingleProductViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
