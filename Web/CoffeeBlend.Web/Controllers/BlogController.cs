namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
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
                Blogs = this.blogService.GetAll<BlogInListViewModel>(id, itemsPerPage),
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

            return this.Redirect("/");
        }

        public IActionResult Details(int id)
        {
            var blog = this.blogService.GetById<SingleBlogViewModel>(id);

            return this.View(blog);
        }
    }
}
