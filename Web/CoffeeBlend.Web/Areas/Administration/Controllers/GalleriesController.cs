namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.GalleryViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class GalleriesController : AdministrationController
    {
        private readonly IGalleryService galleryService;

        public GalleriesController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        // GET: Administration/Galleries
        public async Task<IActionResult> Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 6;

            var viewModel = new GalleryInListViewModel
            {
                PageNumber = id,
                ItemsPerPage = itemsPerPage,
                ItemsCount = this.galleryService.GetCount(),
                Photos = await this.galleryService.GetAllWithDeletedAsync<GalleryViewModel>(id),
            };

            return this.View(viewModel);
        }

        // GET: Administration/Galleries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var gallery = await this.galleryService.GetByIdAsync<GalleryViewModel>(id);

            return this.View(gallery);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gallery = await this.galleryService.GetByIdAsync<GalleryViewModel>(id);

            return this.View(gallery);
        }

        // POST: Administration/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GalleryViewModel gallery)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(gallery);
            }

            await this.galleryService.UpdateAsync(gallery);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Galleries/Create
        public IActionResult Create()
        {
            var viewModel = new CreateGalleryInputModel();

            return this.View(viewModel);
        }

        // POST: Administration/Galleries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGalleryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.galleryService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Galleries/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var gallery = await this.galleryService.GetByIdAsync<GalleryViewModel>(id);

            return this.View(gallery);
        }

        // POST: Administration/Galleries/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.galleryService.DeleteByIdAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
