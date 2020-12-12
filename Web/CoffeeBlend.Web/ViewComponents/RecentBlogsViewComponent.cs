namespace CoffeeBlend.Web.ViewComponents
{
    using System.Threading.Tasks;

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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new BlogListViewModel
            {
                Blogs = await this.blogService.GetMostRecentAsync<BlogInListViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
