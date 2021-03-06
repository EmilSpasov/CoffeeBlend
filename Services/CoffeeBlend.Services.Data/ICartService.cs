﻿namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface ICartService
    {
        Task AddAsync(string userId, SingleProductViewModel model);

        T GetCurrentUserCart<T>(string userId);

        Task RemoveProductByIdAndSizeAsync(string userId, int id, string size);

        Task UpdateCartProductAsync(CartProductsViewModel model);

        Task<Cart> CurrentUserCart(string userId);

        int GetProductsCount(string userId);
    }
}
