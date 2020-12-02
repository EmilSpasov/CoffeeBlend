namespace CoffeeBlend.Web.Controllers
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public ShoppingCartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var currentUserId = currentUser.Id;

            var viewModel = this.cartService.GetCurrentUserCart<CartViewModel>(currentUserId);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(SingleProductViewModel model)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var currentUserId = currentUser.Id;

            await this.cartService.AddAsync(currentUserId, model);

            return this.Redirect("/ShoppingCart/Index");
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var currentUserId = currentUser.Id;

            await this.cartService.RemoveProductByIdAsync(currentUserId, id);

            return this.Redirect("/ShoppingCart/Index");
        }

        public IActionResult Checkout()
        {
            return this.View();
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
