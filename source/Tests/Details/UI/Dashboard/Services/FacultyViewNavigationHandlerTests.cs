using EllAid.Details.UI.Dashboard.Services;
using EllAid.UseCases.Dashboard;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace EllAid.Tests.Details.UI.Dashboard.Services
{
    public class FacultyViewNavigationHandlerTests
    {
        string navigatedPath = string.Empty;

        [Fact]
        public void Handle_WhenValidDestination_RedirectsToConvertedPath()
        {
            string convertedPath = "/Test/Path";
            //Given
            Mock<IFacultyNavigationConverter> converterMock = new Mock<IFacultyNavigationConverter>();
            converterMock.Setup(mock => mock.Convert(It.IsNotIn<NavigationDestinations>(new[] { NavigationDestinations.Invalid}))).Returns(convertedPath);
            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            // accessorMock.Setup(mock => mock.HttpContext).Returns(new DefaultHttpContext());
            accessorMock.Setup(mock => mock.HttpContext.Response.Redirect(It.IsAny<string>())).Callback<string>((obj) => navigatedPath = obj);
            // Mock<ITempDataProvider> providerMock = new Mock<ITempDataProvider>();

            FacultyViewNavigationHandler handler = new FacultyViewNavigationHandler(converterMock.Object, accessorMock.Object);
            //When
            handler.Handle(NavigationDestinations.Login);
            //Then
            Assert.Equal(convertedPath, navigatedPath);
            accessorMock.Verify(mock => mock.HttpContext.Response.Redirect(It.IsAny<string>()), Times.Once);
        }
    }
}