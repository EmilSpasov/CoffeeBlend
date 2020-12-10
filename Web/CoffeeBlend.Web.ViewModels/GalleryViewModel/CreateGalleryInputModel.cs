namespace CoffeeBlend.Web.ViewModels.GalleryViewModel
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateGalleryInputModel
    {
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
