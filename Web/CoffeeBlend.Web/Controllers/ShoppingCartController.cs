namespace CoffeeBlend.Web.Controllers
{

    using CoffeeBlend.Web.ViewModels.OrderViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : BaseController
    {
        public IActionResult Index()
        {
            var viewModel = new CartViewModel();

            return this.View(viewModel);
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
