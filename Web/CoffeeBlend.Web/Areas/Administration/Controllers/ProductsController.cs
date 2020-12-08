namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ProductsController : AdministrationController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ApplicationDbContext context, ICategoryService categoryService, IProductService productService)
        {
            _context = context;
            this.categoryService = categoryService;
            this.productService = productService;
        }

        // GET: Administration/Products
        public async Task<IActionResult> Index(int id = 1)
        {
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
                Products = await this.productService.GetAllAsync<AdministrationProductsViewModel>(id),
            };
            //var viewModel = new BlogListViewModel
            //{
            //    ItemsPerPage = itemsPerPage,
            //    PageNumber = id,
            //    BlogsCount = this.blogService.GetCount(),
            //    Blogs = this.blogService.GetAll<BlogInListViewModel>(id),
            //};
            //var applicationDbContext = _context.Products.Include(p => p.CategoryProduct).Include(p => p.Image);
            //return View(await applicationDbContext.ToListAsync());

            return this.View(viewModel);
        }

        // GET: Administration/Products/Create
        public IActionResult Create()
        {
            var viewModel = new CreateProductInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }


        // POST: Administration/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            return this.Redirect("/Menu");
        }

        // GET: Administration/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryProductId"] = new SelectList(_context.CategoryProducts, "Id", "Name", product.CategoryProductId);
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Url", product.ImageId);
            return View(product);
        }

        // POST: Administration/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ImageId,Description,Price,CategoryProductId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryProductId"] = new SelectList(_context.CategoryProducts, "Id", "Name", product.CategoryProductId);
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Url", product.ImageId);
            return View(product);
        }

        // GET: Administration/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CategoryProduct)
                .Include(p => p.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
