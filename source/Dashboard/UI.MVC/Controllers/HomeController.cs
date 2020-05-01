using EllAid.Dashboard.UI.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EllAid.Dashboard.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            ViewBag.Title = "Contact Us";
            if (ModelState.IsValid)
            {
                // send the email.
                ViewBag.UserMessage = "Message sent.";
            }
            else
            {
                // show errors.
            }

            return View();
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}