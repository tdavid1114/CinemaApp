using CinemaApp.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class NavBarModel : INavBarModel
    {
        private IMessenger messenger;

        public NavBarModel(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void NavigateToLogin()
        {
            this.messenger.Send("LoginViewModel", "vmchange");
            this.messenger.Send(true, "login");
        }

        public void NavigateToMyTickets()
        {
            this.messenger.Send("MyTicketsViewModel", "vmchange");
        }

        public void changeStatusLoggedOut()
        {
            this.messenger.Send(false, "logstatus");
        }
    }
}