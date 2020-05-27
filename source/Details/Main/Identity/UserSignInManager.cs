using System.Threading.Tasks;
using AspNetCore.Identity.DocumentDb;
using EllAid.Entities;
using Microsoft.AspNetCore.Identity;

namespace EllAid.Details.Main.Identity
{
    public class UserSignInManager : IUserSignInManager
    {
        readonly SignInManager<DocumentDbIdentityUser> manager;
        readonly SignInResultConverter converter;

        public UserSignInManager(SignInManager<DocumentDbIdentityUser> manager, SignInResultConverter converter)
        {
            this.manager = manager;
            this.converter = converter;
        }

        public async Task<UserSignInResult> CheckSignInAsync(string userName, string password)
        {
            DocumentDbIdentityUser user = await manager.UserManager.FindByNameAsync(userName);
            SignInResult result = await manager.CheckPasswordSignInAsync(user, password, false);
            return converter.Convert(result);
        }
    }
}