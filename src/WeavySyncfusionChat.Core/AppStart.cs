using System;
using System.Net.Http;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Config;
using MvvmCross.Exceptions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using WeavySyncfusionChat.Core.Services;
using WeavySyncfusionChat.Core.ViewModels.Home;
using WeavySyncfusionChat.Core.ViewModels.Login;

namespace WeavySyncfusionChat.Core
{

    public class AppStart : MvxAppStart
    {        
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationService _authenticationService;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, ITokenService tokenService, IAuthenticationService authenticationService) : base(application, navigationService)
        {            
            _tokenService = tokenService;
            _authenticationService = authenticationService;
        }

        protected override async Task<object> ApplicationStartup(object hint = null)
        {

            // The image service that loads the images in the conversation list need a jwt token to download the images.
            ImageService.Instance.Initialize(new Configuration
            {                
                HttpClient = new HttpClient(new AuthenticatedHttpImageClientHandler(_tokenService.GenerateToken))
            });

            return await base.ApplicationStartup(hint);

        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {
                // check if we already are authenticated (Note that we always return true in this demo). Check out TokenService where a hard coded jwt bearer token is created.
                var authenticated = await _authenticationService.IsAuthenticated();

                if (authenticated)
                {
                    await NavigationService.Navigate<HomeViewModel>();
                }
                else
                {
                    await NavigationService.Navigate<LoginViewModel>();
                }
            }
            catch (Exception exception)
            {
                throw exception.MvxWrap("Problem navigating to ViewModel at startup");
            }

        }
    }
}
