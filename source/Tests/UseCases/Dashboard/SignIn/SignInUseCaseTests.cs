using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities;
using EllAid.Entities.Services.Validation;
using EllAid.UseCases.Dashboard.SignIn;
using EllAid.UseCases.Dashboard.SignIn.Identity;
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
            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = new ValidationResult()
            };
            await GetUseCase(config).SignInAsync(new UserLoginModel());
            //Then
            Assert.Equal(NavigationLocation.Current, navigatedLocation);
        }

        SignInUseCase GetUseCase(SignInUseCaseConfig config)
        {
            Mock<IValidator<UserLoginModel>> validatorMock = new Mock<IValidator<UserLoginModel>>();
            validatorMock.Setup(mock => mock.Validate(It.IsAny<UserLoginModel>())).Returns(config.ValidationResult);

            Mock<IIdentityProvider> identityProviderMock = new Mock<IIdentityProvider>();
            identityProviderMock.Setup(mock => mock.CheckSignInAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(config.DesiredSignInResult));
            config.SignInExecutorMock ??= new Mock<ISignInExecutor>();
            Mock<INavigator> navigatorMock = new Mock<INavigator>();
            navigatorMock.Setup(mock => mock.NavigateTo(It.IsAny<NavigationLocation>())).Callback<NavigationLocation>((obj) => navigatedLocation = obj);
            config.ErrorCollectorMock ??= new Mock<IErrorCollector>();
            SignInUseCase useCase = new SignInUseCase(validatorMock.Object, identityProviderMock.Object, config.SignInExecutorMock.Object, navigatorMock.Object, config.ErrorCollectorMock.Object, new SignInErrorCreator(new FailedSignInMessageConverter()));
            return useCase;
        }

        [Fact]
        public async Task SignIn_WhenValidationFails_CollectsValidationErrors()
        {
            //Given, When
            List<ValidationError> errors = new List<ValidationError>() { new ValidationError(), new ValidationError() };
            Mock<IErrorCollector> errorCollectorMock = new Mock<IErrorCollector>();
            errorCollectorMock.Setup(mock => mock.AddErrors(errors));
            errorCollectorMock.Setup(mock => mock.Save());
            ValidationResult validationResult = new ValidationResult()
            {
                Errors = errors
            };
            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = validationResult,
                DesiredSignInResult = UserSignInResult.Invalid,
                ErrorCollectorMock = errorCollectorMock
            };
            await GetUseCase(config).SignInAsync(new UserLoginModel());
            //Then
            errorCollectorMock.Verify(mock => mock.AddErrors(errors), Times.Once);
            errorCollectorMock.Verify(mock => mock.Save(), Times.Once);
        }

        [Theory]
        [InlineData(UserSignInResult.Failed)]
        [InlineData(UserSignInResult.LockedOut)]
        [InlineData(UserSignInResult.NotAllowed)]
        [InlineData(UserSignInResult.RequiresTwoFactor)]
        public async Task SignIn_WhenSignInCheckFails_RedirectsToCurrent(UserSignInResult desiredResult)
        {
            //Given, When
            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = new ValidationResult()
                {
                    IsValid = true
                },
                DesiredSignInResult = desiredResult
            };
            await GetUseCase(config).SignInAsync(new UserLoginModel());
            //Then
            Assert.Equal(NavigationLocation.Current, navigatedLocation);
        }

        [Fact]
        public async Task SignIn_WhenSignInCheckFails_CollectsSignInError()
        {
            //Given
            Mock<IErrorCollector> errorCollectorMock = new Mock<IErrorCollector>();
            errorCollectorMock.Setup(mock => mock.AddErrors(It.IsAny<IList<ValidationError>>()));
            errorCollectorMock.Setup(mock => mock.Save());

            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = new ValidationResult()
                {
                    IsValid = true
                },
                DesiredSignInResult = UserSignInResult.Failed,
                ErrorCollectorMock = errorCollectorMock
            };
            //When
            await GetUseCase(config).SignInAsync(new UserLoginModel());
            //Then
            errorCollectorMock.Verify(mock => mock.AddError(It.IsAny<ValidationError>()), Times.Once);
            errorCollectorMock.Verify(mock => mock.Save(), Times.Once);
        }

        [Fact]
        public async Task SignIn_WhenSignInCheckSucceeds_SignsInUser()
        {
            //Given, When
            Mock<ISignInExecutor> signInMock = new Mock<ISignInExecutor>();
            signInMock.Setup(mock => mock.SignInAsync(It.IsAny<string>()));
            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = new ValidationResult()
                {
                    IsValid = true
                },
                SignInExecutorMock = signInMock,
                DesiredSignInResult = UserSignInResult.Success
            };

            await GetUseCase(config).SignInAsync(new UserLoginModel() { Username = "myUserName"});
            //Then
            signInMock.Verify(mock => mock.SignInAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task SignIn_WhenSignInCheckSucceeds_NavigatesToTarget()
        {
            //Given, When
            ValidationResult validationResult = new ValidationResult()
            {
                IsValid = true
            };
            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = validationResult,
                DesiredSignInResult = UserSignInResult.Success
            };
            await GetUseCase(config).SignInAsync(new UserLoginModel());
            //Then
            Assert.Equal(NavigationLocation.Target, navigatedLocation);
        }

        [Fact]
        public async Task SignIn_WhenSinInCheckInvalid_ThrowsException()
        {
            //Given, When, Then
            ValidationResult validationResult = new ValidationResult()
            {
                IsValid = true
            };
            SignInUseCaseConfig config = new SignInUseCaseConfig()
            {
                ValidationResult = validationResult,
                DesiredSignInResult = UserSignInResult.Invalid
            };
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await GetUseCase(config).SignInAsync(new UserLoginModel()));
        }
    }
    class SignInUseCaseConfig
    {
        public ValidationResult ValidationResult { get; set; }
        public UserSignInResult DesiredSignInResult { get; set; }
        public Mock<ISignInExecutor> SignInExecutorMock { get; set; }
        public Mock<IErrorCollector> ErrorCollectorMock { get; set; }
    }
}