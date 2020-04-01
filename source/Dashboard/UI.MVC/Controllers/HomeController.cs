using Microsoft.AspNetCore.Mvc;

namespace EllAid.Dashboard.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}