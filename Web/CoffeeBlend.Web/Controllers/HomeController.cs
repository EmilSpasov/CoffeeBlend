using CoffeeBlend.Services.Data;

namespace CoffeeBlend.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels;
    using CoffeeBlend.Web.ViewModels.ReservationViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IReservationService reservationService;

        public HomeController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.reservationService.CreateAsync(input);

            return this.Redirect("/Home/ConfirmedReservation");
        }

        public IActionResult Services()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        public IActionResult ConfirmedReservation()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
