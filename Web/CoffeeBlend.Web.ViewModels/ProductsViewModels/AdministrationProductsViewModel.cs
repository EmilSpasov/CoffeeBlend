namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class AdministrationProductsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int ImageImageId { get; set; }

        public IFormFile ImageFile { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        [Range(1, 100)]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryProductId { get; set; }

        public string CategoryProductName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
