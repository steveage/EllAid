using System;
using EllAid.Entities;
using EllAid.UseCases.Dashboard;
using EllAid.UseCases.Dashboard.SignIn;
using Xunit;

namespace EllAid.Tests.UseCases.Dashboard.SignIn
{
    public class FailedSignInMessageConverterTests
    {
        [Fact]
        public void Convert_WhenFailed_ReturnsUsernameAndLoginMessage()
        {
            //Given
            FailedSignInMessageConverter converter = new FailedSignInMessageConverter();
            //When
            string message = converter.Convert(UserSignInResult.Failed);
            //Then
            Assert.Equal(DashboardUseCaseConstants.failedSignInMessage, message);
        }

        [Fact]
        public void Convert_WhenLockedOut_ReturnsLockedOutMessage()
        {
            //Given
            FailedSignInMessageConverter converter = new FailedSignInMessageConverter();
            //When
            string message = converter.Convert(UserSignInResult.LockedOut);
            //Then
            Assert.Equal(DashboardUseCaseConstants.lockedOutSignInMessage, message);
        }

        [Fact]
        public void Convert_WhenNotAllowed_ReturnsNotAllowedMessage()
        {
            //Given
            FailedSignInMessageConverter converter = new FailedSignInMessageConverter();
            //When
            string message = converter.Convert(UserSignInResult.NotAllowed);
            //Then
            Assert.Equal(DashboardUseCaseConstants.notAllowedSignInMessage, message);
        }

        [Fact]
        public void Convert_WhenTwoFactorRequired_ReturnsTwoFactorMessage()
        {
            //Given
            FailedSignInMessageConverter converter = new FailedSignInMessageConverter();
            //When
            string message = converter.Convert(UserSignInResult.RequiresTwoFactor);
            //Then
            Assert.Equal(DashboardUseCaseConstants.requiresTwoFactorSignInMessage, message);
        }

        [Fact]
        public void Convert_WhenSuccess_ThrowsException()
        {
            //Given
            FailedSignInMessageConverter converter = new FailedSignInMessageConverter();
            //When, Then
            Assert.Throws<ArgumentException>(() => converter.Convert(UserSignInResult.Success));
        }

        [Fact]
        public void Convert_WhenInvalid_ThrowsException()
        {
            //Given
            FailedSignInMessageConverter converter = new FailedSignInMessageConverter();
            //When, Then
            Assert.Throws<ArgumentException>(() => converter.Convert(UserSignInResult.Invalid));
        }
    }
}