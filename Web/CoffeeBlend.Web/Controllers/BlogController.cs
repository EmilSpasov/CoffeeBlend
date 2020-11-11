namespace CoffeeBlend.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
