namespace CoffeeBlend.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
    using Moq;
    using Xunit;

    public class BlogServiceTests
    {
        [Fact]
        public async Task CreateShouldWorkCorrectly()
        {
            var list = new List<Article>();
            var mockBlogRepository = new Mock<IDeletableEntityRepository<Article>>();
            mockBlogRepository.Setup(x => x.All()).Returns(list.AsQueryable());
            mockBlogRepository.Setup(x => x.AddAsync(It.IsAny<Article>())).Callback(
                (Article article) => list.Add(article));

            var mockImageService = new Mock<IImageService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();
            var mockCommentService = new Mock<ICommentService>();

            var blogService = new BlogService(mockBlogRepository.Object, mockImageService.Object, mockCloudinaryService.Object, mockCommentService.Object);
            await blogService.CreateAsync(new CreateBlogInputModel());

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void GetCountShouldWorkCorrectly()
        {
            var mockBlogRepository = new Mock<IDeletableEntityRepository<Article>>();
            mockBlogRepository.Setup(x => x.All())
                .Returns(new List<Article>
                {
                    new Article(),
                    new Article(),
                }
                .AsQueryable());

            var mockImageService = new Mock<IImageService>();
            var mockCloudinaryService = new Mock<ICloudinaryService>();
            var mockCommentService = new Mock<ICommentService>();

            var blogService = new BlogService(mockBlogRepository.Object, mockImageService.Object, mockCloudinaryService.Object, mockCommentService.Object);

            var articlesCount = blogService.GetCount();

            Assert.Equal(2, articlesCount);
        }
    }
}
