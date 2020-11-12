namespace CoffeeBlend.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Common.Models;

    public class Image : BaseDeletableModel<int>
    {
        [Required]
        public string Url { get; set; }
    }
}
