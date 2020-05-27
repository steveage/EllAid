using System.Threading.Tasks;
using EllAid.UseCases.Dashboard;
using EllAid.UseCases.Dashboard.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EllAid.Details.UI.Dashboard.Controllers
{
    public class AccountController : Controller
    {
        readonly SignInUseCase useCase;
        readonly ILogger<AccountController> logger;

        public AccountController(SignInUseCase useCase, ILogger<AccountController> logger)
        {
            this.useCase = useCase;
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

        [HttpPost]
        public async Task Login(UserLoginModel viewModel)
        {
            await useCase.SignInAsync(viewModel);
        }
    }
}