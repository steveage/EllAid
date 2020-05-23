using System.Threading.Tasks;
using EllAid.Details.Main.Identity;
using EllAid.Details.Web.DataSource.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace EllAid.Tests.Details.Web.DataSource.Controllers
{
    public class IdentityControllerTests
    {
        [Fact]
        public async Task SignIn_WhenCredentialsAreCorrect_ReturnsOK()
        {
            //Given
            IdentityController controller = GetController(UserSignInResult.Success);
            //When
            IActionResult result = await controller.SignIn("userName", "password", false);
            var okResult = result as OkResult;
            //Then
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private IdentityController GetController(UserSignInResult desiredResult)
        {
            ILogger<IdentityController> logger = new Mock<ILogger<IdentityController>>().Object;
            Mock<IUserSignInManager> signInMock = new Mock<IUserSignInManager>();
            signInMock.Setup(mgr => mgr.SignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(Task.FromResult(desiredResult));
            IdentityController controller = new IdentityController(logger, signInMock.Object);
            return controller;
        }

        [Theory]
        [InlineData(UserSignInResult.Invalid)]
        [InlineData(UserSignInResult.LockedOut)]
        [InlineData(UserSignInResult.NotAllowed)]
        [InlineData(UserSignInResult.RequiresTwoFactor)]
        public async Task SignIn_WhenCredentialsAreIncorrect_ReturnsBadRequest(UserSignInResult signInResult)
        {
            //Given
            IdentityController controller = GetController(signInResult);
            //When
            IActionResult result = await controller.SignIn("userName", "password", false);
            var badResult = result as BadRequestResult;
            //Then
            Assert.NotNull(badResult);
            Assert.Equal(400, badResult.StatusCode);        }
    }
}