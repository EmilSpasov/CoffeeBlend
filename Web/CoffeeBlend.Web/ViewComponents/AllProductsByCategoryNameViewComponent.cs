namespace CoffeeBlend.Web.ViewComponents
{
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

        public IViewComponentResult Invoke(string name)
        {
            var viewModel = new ProductsListViewModel
            {
                Products = this.productService.GetAllByCategoryName<ProductViewModel>(name),
            };

            return this.View(viewModel);
        }
    }
}
