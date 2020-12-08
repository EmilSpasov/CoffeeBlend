namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Common;
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

        public async Task<IActionResult> Index(string name = GlobalConstants.CoffeeName)
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = await this.categoryService.GetAllByNameAsync<CategoryInListViewModel>(name),
            };

            return this.View(viewModel);
        }
    }
}
