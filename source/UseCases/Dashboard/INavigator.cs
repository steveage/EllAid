namespace EllAid.UseCases.Dashboard
{
    public enum NavigationLocation
    {
        Invalid = 0,
        Source,
        Current,
        Target
    }
    
    public interface INavigator
    {
        void NavigateTo(NavigationLocation location);
    }
}