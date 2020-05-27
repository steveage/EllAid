using System;
using System.Threading.Tasks;
using EllAid.Entities;
using EllAid.Entities.Services;
using EllAid.UseCases.Dashboard.Identity;

namespace EllAid.UseCases.Dashboard
{
    public class SignInUseCase
    {
        readonly IValidator<UserLoginModel> validator;
        readonly IIdentityProvider identityProvider;
        readonly ISignInExecutor signInExecutor;
        readonly INavigator navigator;

        public SignInUseCase(IValidator<UserLoginModel> validator, IIdentityProvider identityProvider, ISignInExecutor signInExecutor, INavigator navigator)
        {
            this.validator = validator;
            this.identityProvider = identityProvider;
            this.signInExecutor = signInExecutor;
            this.navigator = navigator;
        }

        public async Task SignInAsync(UserLoginModel model)
        {
            await CheckSignInIfValidAsync(model);
        }

        async Task CheckSignInIfValidAsync(UserLoginModel model)
        {
            if (validator.IsValid(model))
            {
                await SignInIfCredentialsOK(model);
            }
            else
            {
                NavigateTo(NavigationLocation.Current);
            }
        }

        void NavigateTo(NavigationLocation location)
        {
            navigator.NavigateTo(location);
        }

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