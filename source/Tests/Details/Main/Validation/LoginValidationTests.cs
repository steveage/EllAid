using EllAid.Details.Main.Validation;
using EllAid.UseCases.Dashboard.Identity;
using FluentValidation.Results;
using Xunit;

namespace EllAid.Tests.Details.Main.Validation
{
    public class LoginValidationTests
    {
        [Fact]
        public void Validate_WhenUserNameNotEntered_ReturnsInvalidResult()
        {
            //Given
            UserLoginValidator validator = new UserLoginValidator();
            UserLoginModel model = new UserLoginModel()
            {
                Password = "myPassword"
            };
            //When
            ValidationResult result = validator.Validate(model);
            //Then
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenPasswordNotEntered_ReturnsInvalidResult()
        {
            //Given
            UserLoginValidator validator = new UserLoginValidator();
            UserLoginModel model = new UserLoginModel()
            {
                Username = "myUsername"
            };
            //When
            ValidationResult result = validator.Validate(model);
            //Then
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenUserNameAndPasswordArePresent_ReturnsValidResult()
        {
            //Given
            UserLoginValidator validator = new UserLoginValidator();
            UserLoginModel model = new UserLoginModel()
            {
                Username = "myUsername",
                Password = "myPassword"
            };
            //When
            ValidationResult result = validator.Validate(model);
            //Then
            Assert.True(result.IsValid);
        }
    }
}