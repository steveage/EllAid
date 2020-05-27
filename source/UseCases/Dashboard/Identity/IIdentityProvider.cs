using System.Threading.Tasks;
using EllAid.Entities;

namespace EllAid.UseCases.Dashboard.Identity
{
    public interface IIdentityProvider
    {
        Task<UserSignInResult> CheckSignInAsync(string userName, string password);
    }
}