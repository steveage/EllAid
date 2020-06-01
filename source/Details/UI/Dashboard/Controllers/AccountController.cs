using System.Threading.Tasks;
using EllAid.Details.UI.Dashboard.Services;
using EllAid.UseCases.Dashboard.SignIn;
using EllAid.UseCases.Dashboard.SignIn.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EllAid.Details.UI.Dashboard.Controllers
{
    public class AccountController : Controller
    {
        readonly SignInUseCase useCase;
        readonly ILogger<AccountController> logger;
        readonly ModelStateUpdater modelStateUpdater;

        public AccountController(SignInUseCase useCase, ILogger<AccountController> logger, ModelStateUpdater modelStateUpdater)
        {
            this.useCase = useCase;
            this.logger = logger;
            this.modelStateUpdater = modelStateUpdater;
        }

        public IActionResult Login()
        {
            modelStateUpdater.AddErrors(ViewData.ModelState);
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