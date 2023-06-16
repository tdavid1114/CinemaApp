using CinemaApp.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class NavBarViewModel : ViewModelBase
    {
        private ITicketsModel ticketsModel;
        private INavBarModel navBarModel;
        public ICommand GoToMovies { get; private set; }
        public ICommand GoToLogin { get; private set; }
        public ICommand GoToMyTickets { get; private set; }
        public ICommand Logout { get; private set; }

        public NavBarViewModel(ITicketsModel ticketsModel, INavBarModel navBarModel)
        {
            this.ticketsModel = ticketsModel;
            this.navBarModel = navBarModel;
            GoToMovies = new RelayCommand(() => this.ticketsModel.NavigateToMovies());
            GoToLogin = new RelayCommand(() => this.navBarModel.NavigateToLogin());
            GoToMyTickets = new RelayCommand(() => this.navBarModel.NavigateToMyTickets());
            Logout = new RelayCommand(() =>
            {
                this.ticketsModel.NavigateToMovies();
                this.navBarModel.changeStatusLoggedOut();
            });
        }
    }
}