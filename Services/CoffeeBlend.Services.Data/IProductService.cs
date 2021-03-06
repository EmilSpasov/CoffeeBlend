﻿namespace CoffeeBlend.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public interface IProductService
    {
        Task CreateAsync(CreateProductInputModel input);

        Task<IEnumerable<T>> GetAllAsync<T>(string sortBy, int pageNumber, int itemsPerPage = 6);

        Task<IEnumerable<T>> GetAllByCategoryNameAsync<T>(string name);

        Task<T> GetSingleProductByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetRelatedProductsByCategoryIdAsync<T>(int categoryId, int productId);

        Task<IEnumerable<T>> GetMostBuyedProductsAsync<T>();

        Task UpdateAsync(AdministrationProductsViewModel product);

        Task DeleteByIdAsync(int id);

        Task IncreaseBuyedCount(int id);

        Task<T> GetByIdAsync<T>(int id);

        int GetCount();
    }
}
