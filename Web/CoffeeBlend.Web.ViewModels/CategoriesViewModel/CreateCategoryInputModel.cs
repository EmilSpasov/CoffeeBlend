namespace CoffeeBlend.Web.ViewModels.CategoriesViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
