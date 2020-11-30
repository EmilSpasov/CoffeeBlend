namespace CoffeeBlend.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.ProductsViewModels;

    public class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;

        public CartService(IDeletableEntityRepository<Cart> cartRepository, IDeletableEntityRepository<Product> productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }

        public async Task AddAsync(string userId, SingleProductViewModel model)
        {
            //var product = this.productRepository
            //    .AllAsNoTracking()
            //    .FirstOrDefault(x => x.Id == model.Id);

            //product.Price = model.Price;
            //product.Quantity = model.Quantity;
            //product.Request = model.Request;

            //var cart = new Cart
            //{
            //    UserId = userId,
            //    TotalPrice = product.Price * product.Quantity,
            //};

            //cart.Products.Add(product);

            //await this.cartRepository.AddAsync(cart);
            //await this.cartRepository.SaveChangesAsync();
        }
    }
}
