using System;
using EllAid.Entities;
using EllAid.Entities.Services.Validation;
using EllAid.UseCases.Dashboard.SignIn;
using Xunit;

namespace EllAid.Tests.UseCases.Dashboard.SignIn
{
    public class SignInErrorCreatorTests
    {
        [Theory]
        [InlineData(UserSignInResult.Failed)]
        [InlineData(UserSignInResult.LockedOut)]
        [InlineData(UserSignInResult.NotAllowed)]
        [InlineData(UserSignInResult.RequiresTwoFactor)]
        public void Create_WhenFailedResult_ReturnsError(UserSignInResult signInResult)
        {
            //Given
            SignInErrorCreator creator = new SignInErrorCreator(new FailedSignInMessageConverter());
            //When
            ValidationError error = creator.Create(signInResult);
            //Then
            Assert.NotNull(error);
            Assert.Empty(error.PropertyName);
            Assert.NotEmpty(error.Message);
        }

        [Theory]
        [InlineData(UserSignInResult.Invalid)]
        [InlineData(UserSignInResult.Success)]
        public void Create_WhenInvalidOrSuccessfulResult_ThrowsException(UserSignInResult signInResult)
        {
            //Given
            SignInErrorCreator creator = new SignInErrorCreator(new FailedSignInMessageConverter());
            //When, Then
            Assert.Throws<ArgumentException>(() => creator.Create(signInResult));
        }
    }
}