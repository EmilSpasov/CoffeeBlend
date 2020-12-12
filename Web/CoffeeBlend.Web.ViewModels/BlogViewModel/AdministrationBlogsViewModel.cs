namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class AdministrationBlogsViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
