using Castle.Components.DictionaryAdapter;
using CinemaApp.Logic;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class LoginModel : ILoginModel
    {
        private IMessenger messenger;
        private IAccountLogic accountLogic;
        private RestHelper restHelper;

        public LoginModel(IMessenger messenger, RestHelper restHelper)
        {
            this.messenger = messenger;
            this.restHelper = restHelper;
        }

        public bool IsLoginSuccessful(string username, string password)
        {
            if (username == null)
            {
                return false;
            }

            var un = this.restHelper.ReadUser(username);
            if (un != null)
            {
                return un.Password == password;
            }
            else
            {
                return false;
            }
        }

        public void ChangeStatusLoggedIn()
        {
            this.messenger.Send(true, "logstatus");
        }

        public void IsRegistrationSuccessful(string username, string password, string confirmpassword, ObservableCollection<string> Errors)
        {
            if (username == null)
            {
                Errors.Add("Username has to be more than 4 characters");
            }
            else
            {
                if (username.Length < 4)
                {
                    Errors.Add("Username has to be more than 4 characters");
                }
                else
                {
                    var un = this.restHelper.ReadUser(username);
                    if (un != null)
                    {
                        Errors.Add("Username is taken");
                    }
                }
            }
            if (password == null || password.Length < 3)
            {
                Errors.Add("Password has to at least 3 characters");
            }
            if (password != null && password != confirmpassword)
            {
                Errors.Add("Passwords are not matching");
            }

            if (Errors.Count == 0)
            {
                this.restHelper.CreateUser(username, password);
            }
        }
    }
}