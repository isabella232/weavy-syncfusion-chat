using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using WeavySyncfusionChat.Core.Services;
using WeavySyncfusionChat.Core.ViewModels.Home;

namespace WeavySyncfusionChat.Core.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;

        public IMvxAsyncCommand SignInCommand { get; private set; }

        public LoginViewModel(IMvxNavigationService navigationService, IAuthenticationService authenticationService)
        {
            SignInCommand = new MvxAsyncCommand(SignInAsync);
            _navigationService = navigationService;
            _authenticationService = authenticationService;                        
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private async Task SignInAsync()
        {
            // sign in
            await InvokeOnMainThreadAsync(async () =>
            {

                var authenticated = await _authenticationService.SignIn(Username, Password);

                if (authenticated)
                {
                    await _navigationService.Navigate<HomeViewModel>();
                }
                else
                {   
                    // Error signing in...
                }

            });

        }
    }
}
