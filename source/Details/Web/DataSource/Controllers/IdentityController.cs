using System.Threading.Tasks;
using EllAid.Details.Main.Identity;
using EllAid.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EllAid.Details.Web.DataSource.Controllers
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
        public async Task<IActionResult> CheckSignIn(string userName, string password)
        {
            UserSignInResult result = await signInManager.CheckSignInAsync(userName, password);
            if (result==UserSignInResult.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}