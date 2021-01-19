namespace CoffeeBlend.Services.Data.Tests
{
    public class CartServiceTests
    {
        //[Fact]
        //public async Task AddIfAddDoesAddTheProductToTheCart()
        //{
        //    var cartProductList = new List<CartProduct>();
        //    var cartList = new List<Cart>();
        //    var productList = new List<Product>();

        //    var mockCartProductRepo = new Mock<IRepository<CartProduct>>();
        //    mockCartProductRepo.Setup(x => x.All()).Returns(cartProductList.AsQueryable());
        //    mockCartProductRepo.Setup(x => x.AddAsync(It.IsAny<CartProduct>()))
        //        .Callback((CartProduct cp) => cartProductList.Add(cp));

        //    var mockCartRepo = new Mock<IDeletableEntityRepository<Cart>>();
        //    mockCartRepo.Setup(x => x.All()).Returns(cartList.AsQueryable());
        //    mockCartRepo.Setup(x => x.AddAsync(It.IsAny<Cart>()))
        //        .Callback((Cart c) => cartList.Add(c));

        //    var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();
        //    mockProductRepo.Setup(x => x.All()).Returns(productList.AsQueryable());
        //    mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>()))
        //        .Callback((Product p) => productList.Add(p));

        //    var cartService = new CartService(mockCartRepo.Object, mockCartProductRepo.Object, mockProductRepo.Object);

        //    await cartService.AddAsync("1", new SingleProductViewModel { Id = 1, });

        //    Assert.Equal(1, cartList.Count);
        //}
    }
}
