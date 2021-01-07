namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;

    public interface ICommentService
    {
        Task AddCommentAsync(Comment comment);
    }
}
