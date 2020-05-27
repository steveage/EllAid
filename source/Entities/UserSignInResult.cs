namespace EllAid.Entities
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
}