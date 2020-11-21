namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.Collections.Generic;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class BlogInListViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
