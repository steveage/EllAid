using System;
using EllAid.Entities;

namespace EllAid.UseCases.Dashboard.SignIn
{
    public class FailedSignInMessageConverter
    {
        internal string Convert(UserSignInResult signInResult) =>
            signInResult switch
            {
                UserSignInResult.Failed => DashboardUseCaseConstants.failedSignInMessage,
                UserSignInResult.LockedOut => DashboardUseCaseConstants.lockedOutSignInMessage,
                UserSignInResult.NotAllowed => DashboardUseCaseConstants.notAllowedSignInMessage,
                UserSignInResult.RequiresTwoFactor => DashboardUseCaseConstants.requiresTwoFactorSignInMessage,
                UserSignInResult.Success => throw new ArgumentException("Only failed results are allowed."),
                UserSignInResult.Invalid => throw new ArgumentException("Unspecified user sign in result"),
                _ => throw new ArgumentException("Unspecified user sign in result")
            };
    }
}