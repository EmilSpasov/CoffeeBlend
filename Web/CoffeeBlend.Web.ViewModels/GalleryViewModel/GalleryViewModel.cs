namespace CoffeeBlend.Web.ViewModels.GalleryViewModel
{
    using System;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class GalleryViewModel : IMapFrom<Gallery>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
