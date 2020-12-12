namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        private readonly IBlogService blogService;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogController(IBlogService blogService, UserManager<ApplicationUser> userManager)
        {
            this.blogService = blogService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 6;

            var viewModel = new BlogListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                ItemsCount = this.blogService.GetCount(),
                Blogs = await this.blogService.GetAllAsync<BlogInListViewModel>(id),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await this.blogService.GetByIdAsync<SingleBlogViewModel>(id);

            return this.View(blog);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(int id, string message)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var userId = currentUser.Id;

            await this.blogService.AddCommentToBlog(userId, id, message);

            return this.RedirectToAction(nameof(this.Details), new { id });
        }
    }
}
