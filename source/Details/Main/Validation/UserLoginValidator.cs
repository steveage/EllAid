using EllAid.Entities.Services.Validation;
using EllAid.UseCases.Dashboard.SignIn.Identity;
using FluentValidation;
using FluentValidation.Results;

namespace EllAid.Details.Main.Validation
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>, Entities.Services.Validation.IValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }

        public new Entities.Services.Validation.ValidationResult Validate(UserLoginModel item)
        {
            var fluentResult = base.Validate(item);
            var result = new Entities.Services.Validation.ValidationResult();
            result.IsValid = fluentResult.IsValid;
            foreach (ValidationFailure failure  in fluentResult.Errors)
            {
                ValidationError error = new ValidationError();
                error.PropertyName = failure.PropertyName;
                error.Message = failure.ErrorMessage;
                result.Errors.Add(error);
            };
            return result;
        }
    }
}