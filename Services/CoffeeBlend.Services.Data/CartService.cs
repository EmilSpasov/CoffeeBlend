namespace CoffeeBlend.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;
    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        // TODO: Refactor and use service instead of repository
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IRepository<CartProduct> cartProductRepository;
        private readonly IProductService productsService;

        public CartService(
            IDeletableEntityRepository<Cart> cartRepository,
            IRepository<CartProduct> cartProductRepository,
            IProductService productsService)
        {
            this.cartRepository = cartRepository;
            this.cartProductRepository = cartProductRepository;
            this.productsService = productsService;
        }

        public async Task AddAsync(string userId, SingleProductViewModel model)
        {
            var userCart = await this.CurrentUserCart(userId);

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
                    Price = model.Price,
                    SubTotalPrice = model.ActualPrice,
                };

                await this.cartProductRepository.AddAsync(cartProduct);

                userCart.CartProducts.Add(cartProduct);
            }
            else
            {
                cartProduct = userCart.CartProducts.FirstOrDefault(x => x.ProductId == model.Id);
                cartProduct.Quantity++;
                cartProduct.SubTotalPrice += model.ActualPrice;
            }

            userCart.TotalPrice += model.ActualPrice;

            this.cartRepository.Update(userCart);
            await this.cartRepository.SaveChangesAsync();
            await this.cartProductRepository.SaveChangesAsync();

            // Increase buyed count temporary for most popular products vc:
            await this.productsService.IncreaseBuyedCount(cartProduct.ProductId);
        }

        public T GetCurrentUserCart<T>(string userId)
        {
            return this.cartRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .To<T>()
                .FirstOrDefault();
        }

        public async Task RemoveProductByIdAndSizeAsync(string userId, int id, string size)
        {
            var userCart = await this.CurrentUserCart(userId);

            var productToRemove = userCart.CartProducts
                .FirstOrDefault(x => x.ProductId == id && x.PortionSize.ToString() == size);

            userCart.CartProducts.Remove(productToRemove);
            userCart.TotalPrice -= productToRemove.SubTotalPrice;

            if (!userCart.CartProducts.Any())
            {
                userCart.TotalPrice = 0;
            }

            this.cartProductRepository.Delete(productToRemove);
            await this.cartProductRepository.SaveChangesAsync();
            await this.cartRepository.SaveChangesAsync();
        }

        public async Task UpdateCartProductAsync(CartProductsViewModel model)
        {
            var totalPrice = 0m;

            var currentProduct = await this.cartProductRepository
                .AllAsNoTracking()
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            currentProduct.Quantity = model.Quantity;
            currentProduct.SubTotalPrice = model.Price * currentProduct.Quantity;

            this.cartProductRepository.Update(currentProduct);
            await this.cartProductRepository.SaveChangesAsync();

            var currentCart = await this.cartRepository
                .All()
                .Where(x => x.Id == currentProduct.CartId)
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync();

            foreach (var product in currentCart.CartProducts)
            {
                totalPrice += product.SubTotalPrice;
            }

            currentCart.TotalPrice = totalPrice;

            this.cartRepository.Update(currentCart);
            await this.cartRepository.SaveChangesAsync();
        }

        public async Task<Cart> CurrentUserCart(string userId)
        {
            var userCart = await this.cartRepository
                .All()
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return userCart;
        }

        public int GetProductsCount(string userId)
        {
            var userCart = this.cartRepository
                .All()
                .Include(c => c.CartProducts)
                .FirstOrDefault(x => x.UserId == userId);

            return userCart.CartProducts.Count;
        }
    }
}
