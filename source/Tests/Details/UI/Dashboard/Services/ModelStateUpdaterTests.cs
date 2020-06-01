using System.Collections.Generic;
using EllAid.Details.Main;
using EllAid.Details.UI.Dashboard.Services;
using EllAid.Entities.Services.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace EllAid.Tests.Details.UI.Dashboard.Services
{
    public class ModelStateUpdaterTests
    {
        [Fact]
        public void AddErrors_WhenSerializedErrorsIsNull_DoesNotAddErrors()
        {
            //Given
            IDictionary<string, object> tempDataObjects = new Dictionary<string, object>();
            Mock<ITempDataProvider> providerMock = new Mock<ITempDataProvider>();
            providerMock.Setup(mock => mock.LoadTempData(It.IsAny<HttpContext>())).Returns(tempDataObjects);

            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            ModelStateUpdater updater = new ModelStateUpdater(providerMock.Object, accessorMock.Object);

            ModelStateDictionary modelState = new ModelStateDictionary();
            //When
            updater.AddErrors(modelState);
            //Then
            Assert.Equal(0, modelState.ErrorCount);
            Assert.True(modelState.IsValid);
        }

        [Fact]
        public void AddErrors_WhenSerializedErrorsExist_AddsErrors()
        {
            //Given
            List<ValidationError> errors = new List<ValidationError>()
            {
                new ValidationError()
                {
                    PropertyName = "Username",
                    Message = "Message1"
                },
                new ValidationError()
                {
                    PropertyName = "Password",
                    Message = "Message2"
                }
            };
            string serializedErrors = JsonConvert.SerializeObject(errors);
            IDictionary<string, object> tempDataObjects = new Dictionary<string, object>();
            tempDataObjects.Add(Constants.tempDataErrorDictionaryName, serializedErrors);
            Mock<ITempDataProvider> providerMock = new Mock<ITempDataProvider>();
            providerMock.Setup(mock => mock.LoadTempData(It.IsAny<HttpContext>())).Returns(tempDataObjects);

            Mock<IHttpContextAccessor> accessorMock = new Mock<IHttpContextAccessor>();
            ModelStateUpdater updater = new ModelStateUpdater(providerMock.Object, accessorMock.Object);

            ModelStateDictionary modelState = new ModelStateDictionary();
            //When
            updater.AddErrors(modelState);
            //Then
            Assert.Equal(errors.Count, modelState.ErrorCount);
            Assert.False(modelState.IsValid);
        }
    }
}