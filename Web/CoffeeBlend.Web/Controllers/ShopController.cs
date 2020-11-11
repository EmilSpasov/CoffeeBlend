namespace CoffeeBlend.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShopController : BaseController
    {
        public IActionResult BestSellers()
        {
            return this.View();
        }

        public IActionResult Gallery()
        {
            return this.View();
        }
    }
}
