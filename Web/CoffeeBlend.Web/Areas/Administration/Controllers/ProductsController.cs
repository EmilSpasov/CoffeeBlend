using CoffeeBlend.Common;

namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdministrationController
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        // GET: Administration/Products
        public async Task<IActionResult> Index(string sortBy, int id = 1)
        {
            this.ViewBag.CurrentSortOrder = sortBy;

            this.ViewBag.NameSortParam = sortBy == GlobalConstants.NameAsc ? GlobalConstants.NameDesc : GlobalConstants.NameAsc;
            this.ViewBag.PriceSortParam = sortBy == GlobalConstants.PriceAsc ? GlobalConstants.PriceDesc : GlobalConstants.PriceAsc;
            this.ViewBag.CategorySortParam = sortBy == GlobalConstants.CategoryAsc ? GlobalConstants.CategoryDesc : GlobalConstants.CategoryAsc;
            this.ViewBag.CreatedOnSortParam = sortBy == GlobalConstants.CreatedOnAsc ? GlobalConstants.CreatedOnDesc : GlobalConstants.CreatedOnAsc;

            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 6;

            var viewModel = new AdministrationProductsInListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                ItemsCount = this.productService.GetCount(),
                Products = await this.productService.GetAllAsync<AdministrationProductsViewModel>(sortBy, id),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productService.GetSingleProductByIdAsync<AdministrationProductsViewModel>(id);

            return this.View(product);
        }

        // GET: Administration/Products/Create
        public IActionResult Create()
        {
            var viewModel = new CreateProductInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        // POST: Administration/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.productService.CreateAsync(input);

            this.TempData["Message"] = "Product added successfully.";

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await this.productService.GetByIdAsync<AdministrationProductsViewModel>(id);
            viewModel.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        // POST: Administration/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdministrationProductsViewModel product)
        {
            if (id != product.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(product);
            }

            await this.productService.UpdateAsync(product);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await this.productService.GetByIdAsync<AdministrationProductsViewModel>(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.productService.DeleteByIdAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
