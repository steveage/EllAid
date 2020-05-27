using EllAid.UseCases.Dashboard.Identity;
using FluentValidation;

namespace EllAid.Details.Main.Validation
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>, Entities.Services.IValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }

        public bool IsValid(UserLoginModel item) => Validate(item).IsValid;
    }
}