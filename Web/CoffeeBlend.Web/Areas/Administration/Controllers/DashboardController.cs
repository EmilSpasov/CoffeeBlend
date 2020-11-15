namespace CoffeeBlend.Web.Areas.Administration.Controllers
{
    using CoffeeBlend.Services.Data;
    using CoffeeBlend.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
