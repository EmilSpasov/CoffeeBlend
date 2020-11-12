namespace CoffeeBlend.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }
    }
}
