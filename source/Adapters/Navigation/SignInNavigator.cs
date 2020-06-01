using System;

namespace EllAid.UseCases.Dashboard.SignIn
{
    public class SignInNavigator : INavigator
    {
        readonly INavigationHandler handler;

        public SignInNavigator(INavigationHandler handler)
        {
            this.handler = handler;
        }

        public void NavigateTo(NavigationLocation location)
        {
            handler.Handle(GetDestination(location));
        }

        NavigationDestinations GetDestination(NavigationLocation location) =>
            location switch
            {
                NavigationLocation.Current => NavigationDestinations.Login,
                NavigationLocation.Target => NavigationDestinations.Faculty,
                _ => throw new ArgumentException("Invalid enum value", nameof(location))
            };
    }
}