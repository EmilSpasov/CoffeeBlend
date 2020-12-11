namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.GalleryViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class ShopController : BaseController
    {
        private readonly IGalleryService galleryService;

        public ShopController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        public IActionResult BestSellers()
        {
            return this.View();
        }

        public async Task<IActionResult> Gallery()
        {
            var viewModel = new GalleryInListViewModel
            {
                Photos = await this.galleryService.GetAllAsync<GalleryViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
