namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface IProductService
    {
        Task CreateAsync(CreateProductInputModel input);

        IEnumerable<T> GetAll<T>();
    }
}
