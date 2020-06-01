using System.Threading.Tasks;
using EllAid.Entities;

namespace EllAid.UseCases.Dashboard.SignIn.Identity
{
    public interface IIdentityProvider
    {
        Task<UserSignInResult> CheckSignInAsync(string userName, string password);
    }
}