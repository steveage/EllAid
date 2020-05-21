using System.Threading.Tasks;
using EllAid.Adapters.DataObjects;
using EllAid.Dashboard.UI.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace EllAid.Dashboard.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        readonly ILogger<AccountController> logger;
        readonly SignInManager<InstructorDto> signInManager;

        public AccountController(ILogger<AccountController> logger, SignInManager<InstructorDto> signInManager)
        {
            this.logger = logger;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"][0]);
                    }
                    else
                    {
                        return RedirectToAction("Faculty", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Failed to log in.");
            return View();
        }
    }
}