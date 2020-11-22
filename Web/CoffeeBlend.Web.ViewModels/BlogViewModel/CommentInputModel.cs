namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
