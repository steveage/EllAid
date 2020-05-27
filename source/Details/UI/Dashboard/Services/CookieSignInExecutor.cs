using System.Security.Claims;
using System.Threading.Tasks;
using EllAid.UseCases.Dashboard.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace EllAid.Details.UI.Dashboard.Services
{
    class CookieSignInExecutor : ISignInExecutor
    {
        readonly IHttpContextAccessor accessor;

        public CookieSignInExecutor(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }
        public async Task SignInAsync(string userName)
        {
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                   
        }
    }
}