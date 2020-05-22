using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EllAid.DataSource.Infrastructure.Web.Controllers
{
    public class IdentityController : ControllerBase
    {
        readonly ILogger<IdentityController> logger;
        readonly IUserSignInManager signInManager;

        public IdentityController(ILogger<IdentityController> logger, IUserSignInManager signInManager)
        {
            this.logger = logger;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(string userName, string password, bool rememberMe = false)
        {
            UserSignInResult result = await signInManager.SignInAsync(userName, password, rememberMe);
            if (result==UserSignInResult.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}