using System.Collections.Generic;
using EllAid.Details.Main;
using EllAid.Details.Main.Error;
using EllAid.Entities.Services.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace EllAid.Tests.Details.Main.Error
{
    public class TempDataErrorCollectorTests
    {
        IDictionary<string, object> createdTempData;

        [Fact]
        public void Save_AddsErrorsToTempData()
        {
            //Given
            TempDataErrorCollector collector = GetCollector();
            
            List<ValidationError> errors = new List<ValidationError>()
            {
                new ValidationError()
                {
                    PropertyName = "MyProperty1",
                    Message = "MyMessage1"
                },
                new ValidationError()
                {
                    PropertyName = "MyProperty2",
                    Message = "MyMessage2"
                }
            };
            //When
            collector.AddErrors(errors);
            collector.Save();
            //Then
            Assert.Single(createdTempData);
            Assert.True(createdTempData.ContainsKey(Constants.tempDataErrorDictionaryName));
            List<ValidationError> deserializedErrors = JsonConvert.DeserializeObject<List<ValidationError>>(createdTempData[Constants.tempDataErrorDictionaryName].ToString());
            Assert.Equal(errors.Count, deserializedErrors.Count);
            Assert.Equal(errors[0].PropertyName, deserializedErrors[0].PropertyName);
            Assert.Equal(errors[0].Message, deserializedErrors[0].Message);
            Assert.Equal(errors[1].PropertyName, deserializedErrors[1].PropertyName);
            Assert.Equal(errors[1].Message, deserializedErrors[1].Message);
        }

        TempDataErrorCollector GetNonSetupCollector()
        {
            Mock<ITempDataProvider> dataProviderMock = new Mock<ITempDataProvider>();
            Mock<IHttpContextAccessor> contextAccessorMock = new Mock<IHttpContextAccessor>();
            return new TempDataErrorCollector(dataProviderMock.Object, contextAccessorMock.Object);
        }

        [Fact]
        public void Save_WhenNoErrors_DoesNotAddErrorsToTempData()
        {
            //Given
            TempDataErrorCollector collector = GetCollector();
            //When
            collector.Save();
            //Then
            Assert.Null(createdTempData);
        }

        TempDataErrorCollector GetCollector()
        {
            Mock<ITempDataProvider> providerMock = new Mock<ITempDataProvider>();
            providerMock.Setup(mock => mock.SaveTempData(It.IsAny<HttpContext>(), It.IsAny<IDictionary<string, object>>())).Callback<HttpContext, IDictionary<string, object>>((cont, obj) => createdTempData = obj);
            Mock<IHttpContextAccessor> contextAccessor = new Mock<IHttpContextAccessor>();
            contextAccessor.Setup(mock => mock.HttpContext).Returns(new DefaultHttpContext());
            return new TempDataErrorCollector(providerMock.Object, contextAccessor.Object);

        }

        [Fact]
        public void AddError_AddsErrorToList()
        {
            //Given
            TempDataErrorCollector collector = GetNonSetupCollector();
            //When
            collector.AddError(new ValidationError());
            //Then
            Assert.Equal(1, collector.Count);
        }

        [Fact]
        public void AddErrors_AddsErrorsToList()
        {
            TempDataErrorCollector collector = GetNonSetupCollector();
            List<ValidationError> errors = new List<ValidationError>() { new ValidationError(), new ValidationError() };
            //When
            collector.AddErrors(errors);
            //Then
            Assert.Equal(errors.Count, collector.Count);
        }
    }
}