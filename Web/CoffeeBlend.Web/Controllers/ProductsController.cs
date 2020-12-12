namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productService.GetSingleProductByIdAsync<SingleProductViewModel>(id);

            return this.View(product);
        }
    }
}
