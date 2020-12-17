namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrdersController(UserManager<ApplicationUser> userManager, IOrderService orderService, ICartService cartService)
        {
            this.userManager = userManager;
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var currentUserId = currentUser.Id;

            var currentCart = this.cartService.GetCurrentUserCart<CartViewModel>(currentUserId);

            var viewModel = new CreatePaymentInputModel
            {
                TotalPrice = currentCart.TotalPrice,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePaymentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var currentUser = await this.userManager.GetUserAsync(this.User);

            var currentUserId = currentUser.Id;

            await this.orderService.CreateOrderAsync(currentUserId, input);

            return this.RedirectToAction(nameof(this.ThankYou));
        }

        [Authorize]
        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
