using EllAid.DataSource.Infrastructure.Web;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace EllAid.DataSource.Tests.Infrastructure.DataAccess.Web
{
    public class SignInResultConverterTests
    {
        [Fact]
        public void Convert_WhenSuccess_ReturnsSuccess()
        {
            //Given, When
            UserSignInResult userResult = GetUserResult(SignInResult.Success);
            //Then
            Assert.Equal(UserSignInResult.Success, userResult);
        }

        UserSignInResult GetUserResult(SignInResult result)
        {
            SignInResultConverter converter = new SignInResultConverter();
            UserSignInResult userResult = converter.Convert(result);
            return userResult;
        }

        [Fact]
        public void Convert_WhenFailed_ReturnsFailed()
        {
            //Given, When
            UserSignInResult userResult = GetUserResult(SignInResult.Failed);
            //Then
            Assert.Equal(UserSignInResult.Failed, userResult);
        }

        [Fact]
        public void Convert_WhenLockedOut_ReturnsLockedOut()
        {
            //Given, When
            UserSignInResult userResult = GetUserResult(SignInResult.LockedOut);
            //Then
            Assert.Equal(UserSignInResult.LockedOut, userResult);
        }


        [Fact]
        public void Convert_WhenNotAllowed_ReturnsFailed()
        {
            //Given, When
            UserSignInResult userResult = GetUserResult(SignInResult.NotAllowed);
            //Then
            Assert.Equal(UserSignInResult.NotAllowed, userResult);
        }

        [Fact]
        public void Convert_WhenTwoFactorRequired_ReturnsRequiredTwoFactor()
        {
            //Given, When
            UserSignInResult userResult = GetUserResult(SignInResult.TwoFactorRequired);
            //Then
            Assert.Equal(UserSignInResult.RequiresTwoFactor, userResult);
        }
    }
}