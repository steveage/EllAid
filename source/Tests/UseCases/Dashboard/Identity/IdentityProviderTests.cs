using System.Net.Http;
using System.Threading.Tasks;
using EllAid.Entities;
using EllAid.Entities.Services;
using EllAid.UseCases.Dashboard.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace EllAid.Tests.UseCases.Dashboard.Identity
{
    public class IdentityProviderTests
    {
        [Fact]
        public async Task CheckSignIn_WhenSuccessFromClient_ReturnsSuccess()
        {
            //Given
            IdentityProvider provider = GetProvider(UserSignInResult.Success);
            //When
            UserSignInResult result = await provider.CheckSignInAsync("myUserName", "myPassword");
            //Then
            Assert.Equal(UserSignInResult.Success, result);
        }

        IdentityProvider GetProvider(UserSignInResult desiredResult)
        {
            Mock<IHttpClientProvider> providerMock = new Mock<IHttpClientProvider>();
            providerMock.Setup(prv => prv.SendAsync(It.IsAny<HttpRequestMessage>())).Returns(Task.FromResult(new HttpResponseMessage()
            {
                Content = new StringContent(desiredResult.ToString())
            }));
            Mock<IConfiguration> configMock = new Mock<IConfiguration>();
            configMock.SetupGet(mock => mock["Services:DataSource:Uri"]).Returns("https://localhost:1234");
            IdentityProvider provider = new IdentityProvider(providerMock.Object, configMock.Object);
            return provider;
        }

        [Theory]
        [InlineData(UserSignInResult.Failed)]
        [InlineData(UserSignInResult.LockedOut)]
        [InlineData(UserSignInResult.NotAllowed)]
        [InlineData(UserSignInResult.RequiresTwoFactor)]
        public async Task CheckSignIn_WhenFailureFromClient_ReturnsFailure(UserSignInResult desiredClientResult)
        {
            //Given
            IdentityProvider provider = GetProvider(desiredClientResult);
            //When
            UserSignInResult result = await provider.CheckSignInAsync("myUserName", "myPassword");
            //Then
            Assert.Equal(desiredClientResult, result);           
        }
    }
}