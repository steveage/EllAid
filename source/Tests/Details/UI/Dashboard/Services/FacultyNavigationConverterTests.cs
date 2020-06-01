using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EllAid.Details.Main;
using EllAid.Details.UI.Dashboard.Services;
using EllAid.UseCases.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using Xunit;

namespace EllAid.Tests.Details.UI.Dashboard.Services
{
    public class FacultyNavigationConverterTests
    {
        [Fact]
        public void Convert_WhenLogin_ReturnsLoginPath()
        {
            //Given
            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            FacultyNavigationConverter converter = new FacultyNavigationConverter(accessorMock.Object);
            NavigationDestinations destination = NavigationDestinations.Login;
            //When
            string path = converter.Convert(destination);
            //Then
            Assert.Equal(Constants.loginViewPath, path);
        }

        [Fact]
        public void Convert_WhenFacultyAndReturnUrlExists_ReturnsFacultyPath()
        {
            //Given
            string pathValue = "/ReturnPath/Test";
            QueryCollection col = new QueryCollection(new Dictionary<string, StringValues>()
            {
                {Constants.returnUrlKey, pathValue}
            });
            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            accessorMock.Setup(mock => mock.HttpContext.Request.Query).Returns(col);
            FacultyNavigationConverter converter = new FacultyNavigationConverter(accessorMock.Object);
            NavigationDestinations destination = NavigationDestinations.Faculty;
            //When
            string path = converter.Convert(destination);
            //Then
            Assert.Equal(pathValue, path);
        }

        [Fact]
        public void Convert_WhenFacultyAndUrlDoesNotExist_ReturnsFacultyPath()
        {
            //Given
            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            accessorMock.Setup(mock => mock.HttpContext.Request.Query.Keys).Returns(new Collection<string>());
            FacultyNavigationConverter converter = new FacultyNavigationConverter(accessorMock.Object);
            NavigationDestinations destination = NavigationDestinations.Faculty;
            //When
            string path = converter.Convert(destination);
            //Then
            Assert.Equal(Constants.facultyViewPath, path);
        }

        [Fact]
        public void Convert_WhenInvalid_ThrowsException()
        {
            //Given
            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            FacultyNavigationConverter converter = new FacultyNavigationConverter(accessorMock.Object);
            NavigationDestinations destination = NavigationDestinations.Invalid;
            //When, Then
            Assert.Throws<ArgumentException>(() => converter.Convert(destination));
        }
    }
}