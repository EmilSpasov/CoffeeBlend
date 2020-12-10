namespace CoffeeBlend.Web.Controllers
{
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;

    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Services.Messaging;
    using CoffeeBlend.Web.ViewModels;
    using CoffeeBlend.Web.ViewModels.ContactViewModel;
    using CoffeeBlend.Web.ViewModels.ReservationViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IContactService contactService;
        private readonly IEmailSender emailSender;

        public HomeController(IReservationService reservationService, IContactService contactService, IEmailSender emailSender)
        {
            this.reservationService = reservationService;
            this.contactService = contactService;
            this.emailSender = emailSender;
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

        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Contact(ContactInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.contactService.CreateAsync(input);

            // SendGrid not working with abv.bg
            var html = new StringBuilder();

            html.AppendLine($"<h1>Hello {input.FullName}!</h1>");
            html.AppendLine($"<h1>Thank you for contacting us at Coffee Blend.</h1>");
            html.AppendLine($"<h1>We will get back to you as soon as possible!</h1>");
            html.AppendLine($"<h1>Best regards, Emil Spasov</h1>");
            await this.emailSender
                .SendEmailAsync("emil4o7e@abv.bg", "CoffeeBlend", input.Email, "Your message has been received:", html.ToString());

            return this.Redirect("/Home/SuccessfulContact");
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [Authorize]
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
