namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.Collections.Generic;

    public class BlogListViewModel : PagingViewModel
    {
        public IEnumerable<BlogInListViewModel> Blogs { get; set; }
    }
}
