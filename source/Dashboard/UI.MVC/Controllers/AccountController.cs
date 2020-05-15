using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EllAid.Dashboard.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        readonly ILogger<AccountController> logger;

        public AccountController(ILogger<AccountController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}