namespace CoffeeBlend.Web.ViewModels.GalleryViewModel
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class GalleryViewModel : IMapFrom<Image>
    {
        public IEnumerable<Image> ImageUrl { get; set; }
    }
}
