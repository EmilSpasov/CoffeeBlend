using Microsoft.AspNetCore.Authorization;

namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
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

        public IActionResult All(int id = 1)
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
                BlogsCount = this.blogService.GetCount(),
                Blogs = this.blogService.GetAll<BlogInListViewModel>(id),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.blogService.CreateAsync(input);

            return this.Redirect("/Blog/All");
        }

        public IActionResult Details(int id)
        {
            var blog = this.blogService.GetById<SingleBlogViewModel>(id);

            return this.View(blog);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(int id, string message)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var userId = currentUser.Id;

            await this.blogService.AddCommentToBlog(userId, id, message);

            return this.Redirect("/Blog/All");
        }
    }
}
