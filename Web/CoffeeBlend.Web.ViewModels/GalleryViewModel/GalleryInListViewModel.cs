namespace CoffeeBlend.Web.ViewModels.GalleryViewModel
{
    using System.Collections.Generic;

    public class GalleryInListViewModel : PagingViewModel
    {
        public IEnumerable<GalleryViewModel> Photos { get; set; }
    }
}
