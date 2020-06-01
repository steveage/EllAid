namespace EllAid.UseCases.Dashboard
{
    public static class DashboardUseCaseConstants
    {
        public const string failedSignInMessage = "Incorrect username of password";
        public const string lockedOutSignInMessage = "You have been locked out.";
        public const string notAllowedSignInMessage = "Your email address has not been confirmed yet.";
        public const string requiresTwoFactorSignInMessage = "Two factor authentication is required.";
    }
}