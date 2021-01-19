namespace CoffeeBlend.Web.ViewModels.CommentViewModel
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class CreateCommentInputModel : IMapFrom<Comment>
    {
        public string UserId { get; set; }

        public int ArticleId { get; set; }

        [Required]
        [MaxLength(2000)]
        [MinLength(2)]
        public string Content { get; set; }
    }
}
