using Microsoft.AspNetCore.Mvc;

namespace TinyShoppingCart.Server.Presentation.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View("Index");
        }
    }
}