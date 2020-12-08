namespace CoffeeBlend.Web.ViewComponents
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.MenuViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class AllProductsByCategoryNameViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public AllProductsByCategoryNameViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            var viewModel = new ProductsListViewModel
            {
                Products = await this.productService.GetAllByCategoryNameAsync<ProductViewModel>(name),
            };

            return this.View(viewModel);
        }
    }
}
