namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateBlogInputModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        [MinLength(100)]
        public string Content { get; set; }

        [Required]
        [MinLength(4)]
        public string AuthorName { get; set; }
    }
}
