namespace CoffeeBlend.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        [MaxLength(20000)]
        public string Content { get; set; }

        [Required]
        [MaxLength(30)]
        public string AuthorName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
