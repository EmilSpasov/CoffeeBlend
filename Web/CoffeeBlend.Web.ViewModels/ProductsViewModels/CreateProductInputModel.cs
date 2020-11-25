namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateProductInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

        public string Description { get; set; }

        [Range(1, 100)]
        public decimal Price { get; set; }

        public int CategoryProductId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
