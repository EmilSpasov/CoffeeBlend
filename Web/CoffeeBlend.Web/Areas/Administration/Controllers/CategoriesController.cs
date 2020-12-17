namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.CategoriesViewModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Administration/Categories
        public async Task<IActionResult> Index()
        {
            var viewModel = new AdministrationCategoryInListViewModel
            {
                Categories = await this.categoryService.GetAllWithDeletedAsync<AdministrationCategoryViewModel>(),
            };

            return this.View(viewModel);
        }

        // GET: Administration/Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await this.categoryService.GetByIdAsync<AdministrationCategoryViewModel>(id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // GET: Administration/Categories/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Categories/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoryService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await this.categoryService.GetByIdAsync<AdministrationCategoryViewModel>(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // POST: Administration/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] AdministrationCategoryViewModel category)
        {
            if (id != category.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.categoryService.UpdateAsync(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CategoryExists(category.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(category);
        }

        // GET: Administration/Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await this.categoryService.GetByIdAsync<AdministrationCategoryViewModel>(id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.categoryService.DeleteByIdAsync(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CategoryExists(int id)
        {
            return this.categoryService.DoesCategoryExists(id);

            // return this.db.CategoryProducts.Any(e => e.Id == id);
        }
    }
}
