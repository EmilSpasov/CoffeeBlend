namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public IActionResult Details(int id)
        {
            var product = this.productService.GetSingleProductById<SingleProductViewModel>(id);

            return this.View(product);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProductInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.productService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
