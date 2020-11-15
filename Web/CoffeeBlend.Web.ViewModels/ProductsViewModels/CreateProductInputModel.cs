using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    public class CreateProductInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int? ImageId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryProductId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
