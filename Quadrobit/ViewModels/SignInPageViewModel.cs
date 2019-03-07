#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 06 03 2019

#endregion

#region

using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quadrobit.Abstractions;
using Quadrobit.Models;

#endregion

namespace Quadrobit.ViewModels
{
    public class SignInPageViewModel : MvxViewModel
    {
        private readonly IApiService _apiService;
        private readonly IMvxNavigationService _navigationService;
        private string _password;

        private string _username;

        public SignInPageViewModel(IApiService apiService, IMvxNavigationService navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IMvxCommand SignInCommand => new MvxCommand(async () => await signIn());

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private async Task signIn()
        {
            if (!validate())
            {
                UserDialogs.Instance.Alert("All fields are mandatory", "Login error");
                return;
            }

            var signInSuccessfull = await _apiService.Login(_username, _password);
            if (signInSuccessfull)
            {
                var payload = new SignInCredentials
                {
                    Username = _username,
                    Password = _password
                };
                Username = Password = null;
                await _navigationService.Navigate<ContentPageViewModel, SignInCredentials>(payload);
            }
            else
            {
                UserDialogs.Instance.Alert("Username or password is incorrect", "Login error");
            }
        }

        private bool validate()
        {
            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
            {
                return false;
            }

            return true;
        }
    }
}