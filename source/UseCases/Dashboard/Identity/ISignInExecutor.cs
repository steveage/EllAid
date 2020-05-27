using System.Threading.Tasks;

namespace EllAid.UseCases.Dashboard.Identity
{
    public interface ISignInExecutor
    {
        Task SignInAsync(string userName);
    }
}