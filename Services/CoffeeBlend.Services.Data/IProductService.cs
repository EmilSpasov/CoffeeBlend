namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface IProductService
    {
        Task CreateAsync(CreateProductInputModel input);
    }
}
