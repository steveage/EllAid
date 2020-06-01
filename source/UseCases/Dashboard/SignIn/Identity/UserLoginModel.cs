namespace EllAid.UseCases.Dashboard.SignIn.Identity
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}