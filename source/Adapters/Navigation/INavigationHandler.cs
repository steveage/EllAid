namespace EllAid.UseCases.Dashboard
{
        public enum NavigationDestinations
    {
        Invalid = 0,
        Login,
        Faculty
    }
    public interface INavigationHandler
    {
        void Handle(NavigationDestinations destination);
    }
}