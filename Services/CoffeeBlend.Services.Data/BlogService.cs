namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.BlogViewModel;
    using Microsoft.EntityFrameworkCore;

    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;
        private readonly IImageService imageService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICommentService commentsService;

        public BlogService(
            IDeletableEntityRepository<Article> articleRepository,
            IImageService imageService,
            ICloudinaryService cloudinaryService,
            ICommentService commentsService)
        {
            this.articleRepository = articleRepository;
            this.imageService = imageService;
            this.cloudinaryService = cloudinaryService;
            this.commentsService = commentsService;
        }

        public async Task CreateAsync(CreateBlogInputModel input)
        {
            var uploadedImage = this.cloudinaryService.UploadAsync(input.ImageFile);
            var imageUrl = uploadedImage.Result;

            await this.imageService.CreateImageAsync(imageUrl);

            var image = this.imageService.GetImageByUrl(imageUrl);

            var article = new Article
            {
                Title = input.Title,
                Image = image,
                Content = input.Content,
                AuthorName = input.AuthorName,
            };

            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 6)
        {
            var blogs = await this.articleRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

            return blogs;

            // 1-6 - page 1
            // 7-12 - page 2
            // 13-18 - page 3
        }

        public async Task<IEnumerable<T>> GetAllWithDeletedAsync<T>(string sortBy, int page, int itemsPerPage = 6)
        {
            var blogs = new List<T>();

            blogs = sortBy switch
            {
                "name_desc" => await this.articleRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderByDescending(x => x.AuthorName)
                                      .Skip((page - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "name_asc" => await this.articleRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderBy(x => x.AuthorName)
                                      .Skip((page - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "createdOn_desc" => await this.articleRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderByDescending(x => x.CreatedOn)
                                      .Skip((page - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                "createdOn_asc" => await this.articleRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderBy(x => x.CreatedOn)
                                      .Skip((page - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
                _ => await this.articleRepository
                                      .AllAsNoTrackingWithDeleted()
                                      .OrderByDescending(x => x.CreatedOn)
                                      .Skip((page - 1) * itemsPerPage)
                                      .Take(itemsPerPage)
                                      .To<T>()
                                      .ToListAsync(),
            };

            return blogs;
        }

        public async Task<IEnumerable<T>> GetMostRecentAsync<T>()
        {
            var recentBlogs = await this.articleRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Take(3)
                .To<T>()
                .ToListAsync();

            return recentBlogs;
        }

        public async Task UpdateAsync(AdministrationBlogsViewModel model)
        {
            var blogToUpdate = await this.articleRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            blogToUpdate.Title = model.Title;
            blogToUpdate.AuthorName = model.AuthorName;
            blogToUpdate.Content = model.Content;
            blogToUpdate.DeletedOn = model.DeletedOn;
            blogToUpdate.ModifiedOn = model.ModifiedOn;
            blogToUpdate.CreatedOn = model.CreatedOn;
            blogToUpdate.IsDeleted = model.IsDeleted;

            this.articleRepository.Update(blogToUpdate);

            await this.articleRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var blogToDelete = await this.articleRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.articleRepository.Delete(blogToDelete);
            await this.articleRepository.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.articleRepository.All().Count();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.articleRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task AddCommentToBlog(string userId, int id, string message)
        {
            await this.commentsService.AddCommentAsync(userId, id, message);

            var blog = this.articleRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var comment = this.commentsService.GetComment(userId, id, message);

            blog.Comments.Add(comment);

            this.articleRepository.Update(blog);
            await this.articleRepository.SaveChangesAsync();
        }
    }
}
