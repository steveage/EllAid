using System.Threading.Tasks;

namespace EllAid.Details.Main.Identity
{
    public enum UserSignInResult
    {
        Invalid = 0,
        Success,
        Failed,
        LockedOut,
        NotAllowed,
        RequiresTwoFactor
    }

    public interface IUserSignInManager
    {
        Task<UserSignInResult> SignInAsync(string userName, string password, bool rememberMe = false);
    }
}