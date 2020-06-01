using System.Threading.Tasks;

namespace EllAid.UseCases.Dashboard.SignIn.Identity
{
    public interface ISignInExecutor
    {
        Task SignInAsync(string userName);
    }
}