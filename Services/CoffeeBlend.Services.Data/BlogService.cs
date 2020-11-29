namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;

    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IRepository<Comment> commentsRepository;

        public BlogService(
            IDeletableEntityRepository<Article> articleRepository,
            IDeletableEntityRepository<Image> imageRepository,
            ICloudinaryService cloudinaryService,
            IRepository<Comment> commentsRepository)
        {
            this.articleRepository = articleRepository;
            this.imageRepository = imageRepository;
            this.cloudinaryService = cloudinaryService;
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(CreateBlogInputModel input)
        {
            var uploadedImage = this.cloudinaryService.UploadAsync(input.ImageFile);
            var imageUrl = uploadedImage.Result;

            var image = new Image
            {
                Url = imageUrl,
            };

            var article = new Article
            {
                Title = input.Title,
                Image = image,
                Content = input.Content,
                AuthorName = input.AuthorName,
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var blogs = this.articleRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return blogs;

            // 1-6 - page 1
            // 7-12 - page 2
            // 13-18 - page 3
        }

        public IEnumerable<T> GetMostRecent<T>()
        {
            var recentBlogs = this.articleRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Take(3)
                .To<T>()
                .ToList();

            return recentBlogs;
        }

        public int GetCount()
        {
            return this.articleRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            return this.articleRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public async Task AddCommentToBlog(string userId, int id, string message)
        {
            var comment = new Comment
            {
                Content = message,
                ArticleId = id,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            var blog = this.articleRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            blog.Comments.Add(comment);
        }
    }
}
