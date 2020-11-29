using Microsoft.AspNetCore.Authorization;

namespace CoffeeBlend.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels;
    using CoffeeBlend.Web.ViewModels.ContactViewModel;
    using CoffeeBlend.Web.ViewModels.ReservationViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IContactService contactService;

        public HomeController(IReservationService reservationService, IContactService contactService)
        {
            this.reservationService = reservationService;
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(CreateReservationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.reservationService.CreateAsync(input);

            return this.Redirect("/Home/ConfirmedReservation");
        }

        public IActionResult ConfirmedReservation()
        {
            return this.View();
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

        [HttpPost]
        public async Task<IActionResult> Contact(ContactInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.contactService.CreateAsync(input);

            return this.Redirect("/Home/SuccessfulContact");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult SuccessfulContact()
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
