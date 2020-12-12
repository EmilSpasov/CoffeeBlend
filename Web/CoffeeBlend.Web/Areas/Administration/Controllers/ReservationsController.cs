namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ReservationViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class ReservationsController : AdministrationController
    {
        private readonly IReservationService reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        // GET: Administration/Reservations
        public async Task<IActionResult> Index()
        {
            var viewModel = new ReservationInListViewModel
            {
                Reservations = await this.reservationService.GetAllAsync<ReservationViewModel>(),
            };

            // TODO: Auto delete reservations that are expired
            return this.View(viewModel);
        }

        // GET: Administration/Reservations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reservation = await this.reservationService.GetByIdAsync<ReservationViewModel>(id);

            return this.View(reservation);
        }

        // GET: Administration/Reservations/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.reservationService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Reservations/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await this.reservationService.GetByIdAsync<ReservationViewModel>(id);

            return this.View(reservation);
        }

        // POST: Administration/Reservations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReservationViewModel reservation)
        {
            if (id != reservation.Id)
            {
                return this.NotFound();
            }

            await this.reservationService.UpdateAsync(reservation);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Reservations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await this.reservationService.GetByIdAsync<ReservationViewModel>(id);

            return this.View(reservation);
        }

        // POST: Administration/Reservations/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.reservationService.DeleteByIdAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
