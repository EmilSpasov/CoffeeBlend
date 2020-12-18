namespace CoffeeBlend.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;
        private readonly IDeletableEntityRepository<Payment> paymentRepository;
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IDeletableEntityRepository<UserOrderHistory> orderHistoryRepository;
        private readonly IRepository<CartProduct> cartProductRepository;

        public OrderService(IDeletableEntityRepository<Order> ordersRepository,
            IDeletableEntityRepository<Payment> paymentRepository,
            IDeletableEntityRepository<Cart> cartRepository, IDeletableEntityRepository<UserOrderHistory> orderHistoryRepository, IRepository<CartProduct> cartProductRepository)
        {
            this.ordersRepository = ordersRepository;
            this.paymentRepository = paymentRepository;
            this.cartRepository = cartRepository;
            this.orderHistoryRepository = orderHistoryRepository;
            this.cartProductRepository = cartProductRepository;
        }

        public async Task CreateOrderAsync(string userId, CreatePaymentInputModel input)
        {
            var cart = await this.cartRepository
                .AllAsNoTracking()
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            var payment = new Payment
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                Town = input.Town,
                PostCode = input.PostCode,
                Email = input.Email,
                Phone = input.Phone,
                Country = input.Country,
                TotalPrice = input.TotalPrice,
                CartId = cart.Id,
            };

            await this.paymentRepository.AddAsync(payment);
            await this.paymentRepository.SaveChangesAsync();

            var orderHistory = new UserOrderHistory
            {
                UserId = userId,
            };

            var order = new Order
            {
                CartId = payment.CartId,
                PaymentId = payment.Id,
                UserId = userId,
                UserOrderHistoryId = orderHistory.Id,
            };

            await this.orderHistoryRepository.AddAsync(orderHistory);
            await this.ordersRepository.AddAsync(order);

            orderHistory.Orders.Add(order);

            await this.orderHistoryRepository.SaveChangesAsync();
            await this.ordersRepository.SaveChangesAsync();

            // Clear current cart
            foreach (var cartProduct in cart.CartProducts)
            {
                this.cartProductRepository.Delete(cartProduct);
            }

            cart.CartProducts.Clear();
            cart.TotalPrice = 0;
            this.cartRepository.Update(cart);
            await this.cartProductRepository.SaveChangesAsync();
            await this.cartRepository.SaveChangesAsync();
        }
    }
}
