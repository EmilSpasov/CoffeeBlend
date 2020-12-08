namespace CoffeeBlend.Web.ViewModels.ProductsViewModels
{
    using System;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class AdministrationProductsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string CategoryProductName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
