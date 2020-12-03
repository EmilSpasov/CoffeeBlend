namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Common;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [Area("Administration")]
        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [Area("Administration")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryInputModel input)
        {
            await this.categoryService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
