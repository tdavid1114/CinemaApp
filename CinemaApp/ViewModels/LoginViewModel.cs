using Castle.Components.DictionaryAdapter;
using CinemaApp.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ITicketsModel ticketsModel;
        private ILoginModel loginModel;
        private INavBarModel navBarModel;

        public ObservableCollection<string> Errors { get; set; }

        public static string currentUser;

        private string username;

        public string Username
        {
            get { return username; }
            set { Set(ref username, value); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { Set(ref password, value); }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { Set(ref confirmPassword, value); }
        }

        private bool loginError;

        public bool LoginError
        {
            get { return loginError; }
            set { Set(ref loginError, value); }
        }

        public ICommand GoToMovies { get; private set; }
        public ICommand Login { get; private set; }
        public ICommand Register { get; private set; }

        public LoginViewModel(ITicketsModel ticketsModel, ILoginModel loginModel, INavBarModel navBarModel)
        {
            this.ticketsModel = ticketsModel;
            this.loginModel = loginModel;
            this.navBarModel = navBarModel;

            Errors = new ObservableCollection<string>();

            LoginError = false;

            Login = new RelayCommand(() =>
            {
                if (this.loginModel.IsLoginSuccessful(Username, Password))
                {
                    LoginError = false;
                    currentUser = Username;
                    this.ticketsModel.NavigateToMovies();
                    this.loginModel.ChangeStatusLoggedIn();
                }
                else
                {
                    LoginError = true;
                }
            });

            Register = new RelayCommand(() =>
            {
                Errors.Clear();
                this.loginModel.IsRegistrationSuccessful(Username, Password, ConfirmPassword, Errors);
                if (Errors.Count == 0)
                {
                    this.navBarModel.NavigateToLogin();
                }
            });
        }
    }
}