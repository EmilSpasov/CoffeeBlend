namespace CoffeeBlend.Web.ViewComponents
{
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

        public IViewComponentResult Invoke()
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = this.categoryService.GetAll<CategoryInListViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
