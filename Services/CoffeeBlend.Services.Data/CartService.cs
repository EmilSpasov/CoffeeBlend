﻿using System.Xml.Linq;

namespace CoffeeBlend.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IRepository<CartProduct> cartProductRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public CartService(IDeletableEntityRepository<Cart> cartRepository, IRepository<CartProduct> cartProductRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.cartRepository = cartRepository;
            this.cartProductRepository = cartProductRepository;
            this.userRepository = userRepository;
        }

        public async Task AddAsync(string userId, SingleProductViewModel model)
        {
            var userCart = this.cartRepository
                .All()
                .Include(c => c.CartProducts)
                .FirstOrDefault(x => x.UserId == userId);

            var cartProduct = new CartProduct();

            if (!userCart.CartProducts.Any(x => x.ProductId == model.Id && x.PortionSize == model.PortionSize))
            {
                cartProduct = new CartProduct
                {
                    PortionSize = model.PortionSize,
                    Name = model.Name,
                    Quantity = model.Quantity,
                    CartId = userCart.Id,
                    ProductId = model.Id,
                    Request = model.Request,
                    SubTotalPrice = model.ActualPrice,
                };

                userCart.CartProducts.Add(cartProduct);
                await this.cartProductRepository.AddAsync(cartProduct);
            }
            else
            {
                cartProduct = userCart.CartProducts.FirstOrDefault(x => x.ProductId == model.Id);
                cartProduct.Quantity += model.Quantity;
            }

            userCart.TotalPrice += model.ActualPrice;

            await this.cartProductRepository.SaveChangesAsync();
        }

        public T GetCurrentUserCart<T>(string userId)
        {
            return this.cartRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .To<T>()
                .FirstOrDefault();
        }

        public async Task RemoveProductByIdAsync(string userId, int id)
        {
            var userCart = this.cartRepository
                .All()
                .Include(c => c.CartProducts)
                .FirstOrDefault(x => x.UserId == userId);

            var productToRemove = userCart.CartProducts
                .FirstOrDefault(x => x.ProductId == id);

            userCart.CartProducts.Remove(productToRemove);
            userCart.TotalPrice -= productToRemove.SubTotalPrice;

            this.cartProductRepository.Delete(productToRemove);
            await this.cartProductRepository.SaveChangesAsync();
            await this.cartRepository.SaveChangesAsync();
        }
    }
}
