﻿namespace CoffeeBlend.Web.Controllers
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(SingleProductViewModel model)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var currentUserId = currentUser.Id;

            await this.cartService.AddAsync(currentUserId, model);

            return this.RedirectToAction(nameof(this.Index));
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id, string size)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var currentUserId = currentUser.Id;

            await this.cartService.RemoveProductByIdAndSizeAsync(currentUserId, id, size);

            return this.RedirectToAction(nameof(this.Index));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateCartProduct([FromBody]CartProductsViewModel currentProduct)
        {
            await this.cartService.UpdateCartProductAsync(currentProduct);

            return this.Json(currentProduct);
        }
    }
}
