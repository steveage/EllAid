using EllAid.Entities;
using EllAid.Entities.Services.Validation;

namespace EllAid.UseCases.Dashboard.SignIn
{
    public class SignInErrorCreator
    {
        readonly FailedSignInMessageConverter converter;

        public SignInErrorCreator(FailedSignInMessageConverter converter)
        {
            this.converter = converter;
        }

        internal ValidationError Create(UserSignInResult signInResult) => new ValidationError()
        {
            PropertyName = string.Empty,
            Message = converter.Convert(signInResult)
        };
    }
}