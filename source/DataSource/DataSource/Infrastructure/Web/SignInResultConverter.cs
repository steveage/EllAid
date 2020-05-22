using Microsoft.AspNetCore.Identity;

namespace EllAid.DataSource.Infrastructure.Web
{
    class SignInResultConverter
    {
        internal UserSignInResult Convert(SignInResult result)
        {
            UserSignInResult userResult = UserSignInResult.Invalid;
            if (result.Succeeded)
            {
                userResult = UserSignInResult.Success;
            }
            else if(result.IsLockedOut)
            {
                userResult = UserSignInResult.LockedOut;
            }
            else if(result.IsNotAllowed)
            {
                userResult = UserSignInResult.NotAllowed;
            }
            else if(result.RequiresTwoFactor)
            {
                userResult = UserSignInResult.RequiresTwoFactor;
            }
            else
            {
                userResult = UserSignInResult.Failed;
            }

            return userResult;
        }
    }
}