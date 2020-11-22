namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class SingleBlogViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        [Required]
        [MinLength(5)]
        public string Message { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
