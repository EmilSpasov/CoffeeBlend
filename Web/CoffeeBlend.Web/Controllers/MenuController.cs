namespace CoffeeBlend.Web.Controllers
{
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.MenuViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class MenuController : BaseController
    {
        private readonly ICategoryService categoryService;

        public MenuController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = this.categoryService.GetAll<CategoryInListViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
