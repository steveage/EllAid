using System;
using System.Threading.Tasks;
using EllAid.Entities;
using EllAid.Entities.Services.Validation;
using EllAid.UseCases.Dashboard.SignIn.Identity;

namespace EllAid.UseCases.Dashboard.SignIn
{
    public class SignInUseCase
    {
        readonly IValidator<UserLoginModel> validator;
        readonly IIdentityProvider identityProvider;
        readonly ISignInExecutor signInExecutor;
        readonly INavigator navigator;
        readonly IErrorCollector errorCollector;
        readonly SignInErrorCreator errorCreator;

        public SignInUseCase(IValidator<UserLoginModel> validator, IIdentityProvider identityProvider, ISignInExecutor signInExecutor, INavigator navigator, IErrorCollector errorCollector, SignInErrorCreator errorCreator)
        {
            this.validator = validator;
            this.identityProvider = identityProvider;
            this.signInExecutor = signInExecutor;
            this.navigator = navigator;
            this.errorCollector = errorCollector;
            this.errorCreator = errorCreator;
        }

        public async Task SignInAsync(UserLoginModel model)
        {
            await CheckSignInIfValidAsync(model);
        }

        async Task CheckSignInIfValidAsync(UserLoginModel model)
        {
            ValidationResult result = validator.Validate(model);
            if (result.IsValid)
            {
                await SignInIfCredentialsOK(model);
            }
            else
            {
                errorCollector.AddErrors(result.Errors);
                errorCollector.Save();
                NavigateTo(NavigationLocation.Current);
            }
        }

        void NavigateTo(NavigationLocation location) => navigator.NavigateTo(location);

        async Task SignInIfCredentialsOK(UserLoginModel model)
        {
            UserSignInResult result = await identityProvider.CheckSignInAsync(model.Username, model.Password);
            if (result==UserSignInResult.Success)
            {
                await SignInUserAsync(model);
            }
            else if (result==UserSignInResult.Invalid)
            {
                throw new InvalidOperationException($"Invalid result received form {nameof(identityProvider)}.");
            }
            else
            {
                errorCollector.AddError(errorCreator.Create(result));
                errorCollector.Save();
                NavigateTo(NavigationLocation.Current);
            }
        }

        async Task SignInUserAsync(UserLoginModel model)
        {
            await signInExecutor.SignInAsync(model.Username);
            NavigateTo(NavigationLocation.Target);
        }
    }
}