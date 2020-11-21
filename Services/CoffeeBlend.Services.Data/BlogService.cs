namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;

    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly ICloudinaryService cloudinaryService;

        public BlogService(IDeletableEntityRepository<Article> articleRepository, IDeletableEntityRepository<Image> imageRepository, ICloudinaryService cloudinaryService)
        {
            this.articleRepository = articleRepository;
            this.imageRepository = imageRepository;
            this.cloudinaryService = cloudinaryService;
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
    }
}
