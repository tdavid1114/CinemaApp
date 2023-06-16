using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;
using CinemaApp.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace CinemaApp
{
    public class Navigation
    {
        public MainViewModel mainViewModel = MainViewModel.GetMainViewModel();
        private readonly ServiceProvider serviceProvider;
        private readonly IServiceCollection service;

        private MoviesViewModel moviesViewModel;
        private SeatsViewModel seatsViewModel;
        private TicketsViewModel ticketsViewModel;
        private LoginViewModel loginViewModel;
        private MyTicketsViewModel myTicketsViewModel;

        public Navigation()
        {
            service = new ServiceCollection();
            service.AddTransient<RestHelper>();

            service.AddTransient<ISeatsModel, SeatsModel>();
            service.AddTransient<IMoviesModel, MoviesModel>();
            service.AddTransient<ITicketsModel, TicketsModel>();
            service.AddTransient<ILoginModel, LoginModel>();
            service.AddTransient<INavBarModel, NavBarModel>();
            service.AddTransient<IMyTicketsModel, MyTicketsModel>();

            service.AddSingleton<IMessenger, Messenger>();
            service.AddSingleton<IMessenger>(Messenger.Default);

            service.AddSingleton<IMainViewModel, MainViewModel>();
            service.AddTransient<MoviesViewModel>();
            service.AddTransient<TicketsViewModel>();
            service.AddTransient<SeatsViewModel>();
            service.AddTransient<LoginViewModel>();
            service.AddTransient<MyTicketsViewModel>();

            serviceProvider = service.BuildServiceProvider();

            Messenger.Default.Register<string>(this, "vmchange", msg =>
            {
                switch (msg)
                {
                    case "SeatsViewModel":
                        ChangeToSeatsVM(serviceProvider.GetService<SeatsViewModel>());
                        break;

                    case "MoviesViewModel":
                        ChangeToMoviesVM(serviceProvider.GetService<MoviesViewModel>());
                        break;

                    case "TicketsViewModel":
                        ChangeToTicketsVM(serviceProvider.GetService<TicketsViewModel>());
                        break;

                    case "LoginViewModel":
                        ChangeToLoginVM(serviceProvider.GetService<LoginViewModel>());
                        break;

                    case "MyTicketsViewModel":
                        ChangeToMyTicketsVM(serviceProvider.GetService<MyTicketsViewModel>());
                        break;
                }
            });
        }

        public void ChangeToMoviesVM(MoviesViewModel moviesViewModel)
        {
            this.moviesViewModel = moviesViewModel;
            mainViewModel.CurrentViewModel = this.moviesViewModel;
        }

        public void ChangeToTicketsVM(TicketsViewModel ticketsViewModel)
        {
            this.ticketsViewModel = ticketsViewModel;
            mainViewModel.CurrentViewModel = this.ticketsViewModel;
        }

        public void ChangeToSeatsVM(SeatsViewModel seatsViewModel)
        {
            this.seatsViewModel = seatsViewModel;
            mainViewModel.CurrentViewModel = this.seatsViewModel;
        }

        public void ChangeToLoginVM(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
            mainViewModel.CurrentViewModel = this.loginViewModel;
        }

        public void ChangeToMyTicketsVM(MyTicketsViewModel myTicketsViewModel)
        {
            this.myTicketsViewModel = myTicketsViewModel;
            mainViewModel.CurrentViewModel = this.myTicketsViewModel;
        }
    }
}