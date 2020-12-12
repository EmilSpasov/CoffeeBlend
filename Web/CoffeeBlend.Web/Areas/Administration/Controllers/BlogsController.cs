namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : AdministrationController
    {
        private readonly IBlogService blogService;

        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        // GET: Administration/Blogs
        public async Task<IActionResult> Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 6;

            var viewModel = new AdministrationBlogsInListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                ItemsCount = this.blogService.GetCount(),
                Blogs = await this.blogService.GetAllWithDeletedAsync<AdministrationBlogsViewModel>(id),
            };

            return this.View(viewModel);
        }

        // GET: Administration/Blogs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var blog = await this.blogService.GetByIdAsync<AdministrationBlogsViewModel>(id);

            return this.View(blog);
        }

        // GET: Administration/Blogs/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Blogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.blogService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Blogs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var article = await this.blogService.GetByIdAsync<AdministrationBlogsViewModel>(id);

            return this.View(article);
        }

        // POST: Administration/Blogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdministrationBlogsViewModel article)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(article);
            }

            await this.blogService.UpdateAsync(article);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Blogs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await this.blogService.GetByIdAsync<AdministrationBlogsViewModel>(id);

            return this.View(blog);
        }

        // POST: Administration/Blogs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.blogService.DeleteByIdAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
