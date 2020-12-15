namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.GalleryViewModel;

    public interface IGalleryService
    {
        Task CreateAsync(CreateGalleryInputModel input);

        Task<IEnumerable<T>> GetAllWithDeletedAsync<T>(int pageNumber, int itemsPerPage = 6);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task UpdateAsync(GalleryViewModel gallery);

        Task DeleteByIdAsync(int id);

        int GetCount();
    }
}
