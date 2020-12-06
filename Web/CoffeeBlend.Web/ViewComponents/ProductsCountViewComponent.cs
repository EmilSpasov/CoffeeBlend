namespace CoffeeBlend.Web.ViewComponents
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsCountViewComponent : ViewComponent
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsCountViewComponent(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await this.userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)this.User);

            var currentUserId = currentUser.Id;

            var viewModel = new CartProductsCount
            {
                ProductsCount = this.cartService.GetProductsCount(currentUserId),
            };

            return this.View(viewModel);
        }
    }
}
