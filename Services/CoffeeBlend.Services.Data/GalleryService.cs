namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.GalleryViewModel;
    using Microsoft.EntityFrameworkCore;

    public class GalleryService : IGalleryService
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<Gallery> galleryRepository;

        public GalleryService(ICloudinaryService cloudinaryService, IDeletableEntityRepository<Gallery> galleryRepository)
        {
            this.cloudinaryService = cloudinaryService;
            this.galleryRepository = galleryRepository;
        }

        public async Task CreateAsync(CreateGalleryInputModel input)
        {
            var uploadedImage = this.cloudinaryService.UploadAsync(input.ImageFile);
            var imageUrl = uploadedImage.Result;

            var image = new Image
            {
                Url = imageUrl,
            };

            var gallery = new Gallery
            {
                Image = image,
            };

            await this.galleryRepository.AddAsync(gallery);
            await this.galleryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return await this.galleryRepository
                .AllAsNoTrackingWithDeleted()
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.galleryRepository
                .AllAsNoTrackingWithDeleted()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(GalleryViewModel gallery)
        {
            var photoToUpdate = await this.galleryRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == gallery.Id);

            photoToUpdate.DeletedOn = gallery.DeletedOn;
            photoToUpdate.ModifiedOn = gallery.ModifiedOn;
            photoToUpdate.IsDeleted = gallery.IsDeleted;
            photoToUpdate.CreatedOn = gallery.CreatedOn;

            this.galleryRepository.Update(photoToUpdate);

            await this.galleryRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var photoToDelete = await this.galleryRepository
                .AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.galleryRepository.Delete(photoToDelete);

            await this.galleryRepository.SaveChangesAsync();
        }
    }
}
