namespace CoffeeBlend.Web.ViewComponents
{
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class RecentBlogsViewComponent : ViewComponent
    {
        private readonly IBlogService blogService;

        public RecentBlogsViewComponent(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new BlogListViewModel
            {
                Blogs = this.blogService.GetMostRecent<BlogInListViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
