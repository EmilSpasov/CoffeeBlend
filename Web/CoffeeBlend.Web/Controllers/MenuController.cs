namespace CoffeeBlend.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MenuController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
