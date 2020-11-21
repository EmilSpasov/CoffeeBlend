namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.Collections.Generic;

    public class BlogListViewModel
    {
        public IEnumerable<BlogInListViewModel> Blogs { get; set; }

        public int PageNumber { get; set; }
    }
}