using System.Threading.Tasks;
using EllAid.Entities;

namespace EllAid.Details.Main.Identity
{
    public interface IUserSignInManager
    {
        Task<UserSignInResult> CheckSignInAsync(string userName, string password);
    }
}