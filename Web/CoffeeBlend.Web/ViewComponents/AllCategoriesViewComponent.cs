namespace CoffeeBlend.Web.ViewComponents
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.MenuViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class AllCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public AllCategoriesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = await this.categoryService.GetAllAsync<CategoryInListViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
