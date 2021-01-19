namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;

    public interface ICommentService
    {
        Task AddCommentAsync(string userId, int id, string message);

        Comment GetComment(string userId, int id, string message);
    }
}
