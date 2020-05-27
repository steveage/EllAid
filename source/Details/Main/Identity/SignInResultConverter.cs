using EllAid.Entities;
using Microsoft.AspNetCore.Identity;

namespace EllAid.Details.Main.Identity
{
    public class SignInResultConverter
    {
        public UserSignInResult Convert(SignInResult result)
        {
            UserSignInResult userResult;
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