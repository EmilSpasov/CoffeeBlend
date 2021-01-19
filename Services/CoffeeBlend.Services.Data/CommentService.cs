namespace CoffeeBlend.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> commentsRepository;

        public CommentService(IRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task AddCommentAsync(string userId, int id, string message)
        {
            var comment = new Comment()
            {
                ArticleId = id,
                UserId = userId,
                Content = message,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public Comment GetComment(string userId, int id, string message)
        {
            return this.commentsRepository
                .All()
                .FirstOrDefault(x => x.UserId == userId && x.ArticleId == id && x.Content == message);
        }
    }
}
