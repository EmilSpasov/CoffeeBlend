﻿namespace CoffeeBlend.Web.Controllers
{
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

        public IActionResult Index(string name = GlobalConstants.CoffeeName)
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = this.categoryService.GetAllByName<CategoryInListViewModel>(name),
            };

            return this.View(viewModel);
        }
    }
}
