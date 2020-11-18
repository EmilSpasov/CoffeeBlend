namespace CoffeeBlend.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
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
