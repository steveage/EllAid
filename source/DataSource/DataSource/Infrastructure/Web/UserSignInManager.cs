using System.Threading.Tasks;
using AspNetCore.Identity.DocumentDb;
using Microsoft.AspNetCore.Identity;

namespace EllAid.DataSource.Infrastructure.Web
{
    class UserSignInManager : IUserSignInManager
    {
        readonly SignInManager<DocumentDbIdentityUser> manager;
        readonly SignInResultConverter converter;

        public UserSignInManager(SignInManager<DocumentDbIdentityUser> manager, SignInResultConverter converter)
        {
            this.manager = manager;
            this.converter = converter;
        }

        public async Task<UserSignInResult> SignInAsync(string userName, string password, bool rememberMe = false)
        {
            SignInResult result = await manager.PasswordSignInAsync(userName, password, rememberMe, false);
            return converter.Convert(result);
        }
    }
}