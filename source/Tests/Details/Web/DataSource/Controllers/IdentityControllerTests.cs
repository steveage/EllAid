using System.Threading.Tasks;
using EllAid.Details.Main.Identity;
using EllAid.Details.Web.DataSource.Controllers;
using EllAid.Entities;
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
            UserSignInResult desiredSignInResult = UserSignInResult.Success;
            IdentityController controller = GetController(desiredSignInResult);
            //When
            IActionResult result = await controller.CheckSignIn("userName", "password");
            OkObjectResult okResult = result as OkObjectResult;
            UserSignInResult returnedResult = (UserSignInResult)okResult.Value;
            //Then
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(desiredSignInResult, returnedResult);
        }

        private IdentityController GetController(UserSignInResult desiredResult)
        {
            ILogger<IdentityController> logger = new Mock<ILogger<IdentityController>>().Object;
            Mock<IUserSignInManager> signInMock = new Mock<IUserSignInManager>();
            signInMock.Setup(mgr => mgr.CheckSignInAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(desiredResult));
            IdentityController controller = new IdentityController(logger, signInMock.Object);
            return controller;
        }

        [Theory]
        [InlineData(UserSignInResult.Invalid)]
        [InlineData(UserSignInResult.LockedOut)]
        [InlineData(UserSignInResult.NotAllowed)]
        [InlineData(UserSignInResult.RequiresTwoFactor)]
        public async Task SignIn_WhenCredentialsAreIncorrect_ReturnsBadRequest(UserSignInResult desiredClientResult)
        {
            //Given
            IdentityController controller = GetController(desiredClientResult);
            //When
            IActionResult result = await controller.CheckSignIn("userName", "password");
            BadRequestObjectResult badResult = result as BadRequestObjectResult;
            UserSignInResult returnedSignInResult = (UserSignInResult)badResult.Value;
            //Then
            Assert.NotNull(badResult);
            Assert.Equal(400, badResult.StatusCode);
            Assert.Equal(desiredClientResult, returnedSignInResult);
        }
    }
}