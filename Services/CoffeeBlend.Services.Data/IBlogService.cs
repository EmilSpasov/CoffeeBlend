namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.BlogViewModel;

    public interface IBlogService
    {
        Task CreateAsync(CreateBlogInputModel input);
    }
}
