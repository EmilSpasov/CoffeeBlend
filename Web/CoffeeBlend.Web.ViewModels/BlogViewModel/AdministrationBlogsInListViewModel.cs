namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.Collections.Generic;

    public class AdministrationBlogsInListViewModel : PagingViewModel
    {
        public IEnumerable<AdministrationBlogsViewModel> Blogs { get; set; }
    }
}
