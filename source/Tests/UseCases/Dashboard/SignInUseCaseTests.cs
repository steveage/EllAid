using System;
using System.Threading.Tasks;
using EllAid.Entities;
using EllAid.Entities.Services;
using EllAid.UseCases.Dashboard;
using EllAid.UseCases.Dashboard.Identity;
using Moq;
using Xunit;

namespace EllAid.Tests.UseCases.Dashboard
{
    public class SignInUseCaseTests
    {
        NavigationLocation navigatedLocation = NavigationLocation.Invalid;

        [Fact]
        public async Task SignIn_WhenValidationFails_RedirectsToCurrent()
        {
            //Given, When
            await GetUseCase(false).SignInAsync(new UserLoginModel());
            //Then
            Assert.Equal(NavigationLocation.Current, navigatedLocation);
        }

        SignInUseCase GetUseCase(bool IsValid, UserSignInResult desiredSignInResult = UserSignInResult.Invalid, Mock<ISignInExecutor> signInExecutorMock = null)
        {
            Mock<IValidator<UserLoginModel>> validatorMock = new Mock<IValidator<UserLoginModel>>();
            validatorMock.Setup(mock => mock.IsValid(It.IsAny<UserLoginModel>())).Returns(IsValid);

            Mock<IIdentityProvider> identityProviderMock = new Mock<IIdentityProvider>();
            identityProviderMock.Setup(mock => mock.CheckSignInAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(desiredSignInResult));
            signInExecutorMock ??= new Mock<ISignInExecutor>();
            Mock<INavigator> navigatorMock = new Mock<INavigator>();
            navigatorMock.Setup(mock => mock.NavigateTo(It.IsAny<NavigationLocation>())).Callback<NavigationLocation>((obj) => navigatedLocation = obj);
            SignInUseCase useCase = new SignInUseCase(validatorMock.Object, identityProviderMock.Object, signInExecutorMock.Object, navigatorMock.Object);
            return useCase;
        }

        [Theory]
        [InlineData(UserSignInResult.Failed)]
        [InlineData(UserSignInResult.LockedOut)]
        [InlineData(UserSignInResult.NotAllowed)]
        [InlineData(UserSignInResult.RequiresTwoFactor)]
        public async Task SignIn_WhenSignInCheckFails_RedirectsToCurrent(UserSignInResult desiredResult)
        {
            //Given, When
            await GetUseCase(true, desiredResult).SignInAsync(new UserLoginModel());
            //Then
            Assert.Equal(NavigationLocation.Current, navigatedLocation);
        }

        [Fact]
        public async Task SignIn_WhenSignInCheckSucceeds_SignsInUser()
        {
            //Given, When
            Mock<ISignInExecutor> signInMock = new Mock<ISignInExecutor>();
            signInMock.Setup(mock => mock.SignInAsync(It.IsAny<string>()));
            await GetUseCase(true, UserSignInResult.Success, signInMock).SignInAsync(new UserLoginModel() { Username = "myUserName"});
            //Then
            signInMock.Verify(mock => mock.SignInAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task SignIn_WhenSignInCheckSucceeds_NavigatesToTarget()
        {
            //Given, When
            await GetUseCase(true, UserSignInResult.Success).SignInAsync(new UserLoginModel());
            //Then
            Assert.Equal(NavigationLocation.Target, navigatedLocation);
        }

        [Fact]
        public async Task SignIn_WhenSinInCheckInvalid_ThrowsException()
        {
            //Given, When, Then
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await GetUseCase(true, UserSignInResult.Invalid).SignInAsync(new UserLoginModel()));        
        }
    }
}