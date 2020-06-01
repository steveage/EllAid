using System;
using EllAid.UseCases.Dashboard;
using EllAid.UseCases.Dashboard.SignIn;
using Moq;
using Xunit;

namespace EllAid.Tests.Adapters.Navigation
{
    public class NavigatorTests
    {
        NavigationDestinations handledDestination = NavigationDestinations.Invalid;
        [Fact]
        public void NavigateToCurrent_DirectsCallToLoginLocation()
        {
            //Given
            SignInNavigator navigator = GetNavigator();
            //When
            navigator.NavigateTo(NavigationLocation.Current);
            //Then
            Assert.Equal(NavigationDestinations.Login, handledDestination);
        }

        SignInNavigator GetNavigator()
        {
            Mock<INavigationHandler> handlerMock = new Mock<INavigationHandler>();
            handlerMock.Setup(handler => handler.Handle(It.IsAny<NavigationDestinations>())).Callback<NavigationDestinations>((obj) => handledDestination = obj);
            SignInNavigator navigator = new SignInNavigator(handlerMock.Object);
            return navigator;
        }

        [Fact]
        public void NavigateToTarget_DirectsCallToFacultyLocation()
        {
            //Given
            SignInNavigator navigator = GetNavigator();
            //When
            navigator.NavigateTo(NavigationLocation.Target);
            //Then
            Assert.Equal(NavigationDestinations.Faculty, handledDestination);
        }

        [Fact]
        public void NavigateToInvalid_ThrowsException()
        {
            //Given
            SignInNavigator navigator = GetNavigator();
            //When, Then
            Assert.Throws<ArgumentException>(()=> navigator.NavigateTo(NavigationLocation.Invalid));
        }
    }
}