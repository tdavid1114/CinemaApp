using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;
using CinemaApp.ViewModels;
using CinemaApp.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CinemaApp
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceprovider;
        private readonly IServiceCollection services;

        public App()
        {
            services = new ServiceCollection();

            services.AddTransient<RestHelper>();
            services.AddSingleton<Navigation>();

            services.AddTransient<CinemaDBContext>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ISeatRepository, SeatRepository>();
            services.AddTransient<IMovieLogic, MovieLogic>();

            services.AddTransient<IMoviesModel, MoviesModel>();
            services.AddTransient<ITicketsModel, TicketsModel>();
            services.AddTransient<ISeatsModel, SeatsModel>();
            services.AddTransient<INavBarModel, NavBarModel>();

            services.AddSingleton<IMessenger, Messenger>();
            services.AddSingleton<IMessenger>(Messenger.Default);

            services.AddSingleton<IMainViewModel, MainViewModel>();
            services.AddSingleton<MoviesViewModel>();
            services.AddSingleton<SeatsViewModel>();
            services.AddTransient<NavBarViewModel>();

            serviceprovider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel mainViewModel = MainViewModel.GetMainViewModel();
            var nav = serviceprovider.GetService<Navigation>();
            var init = serviceprovider.GetService<SeatsViewModel>();
            nav.mainViewModel.CurrentViewModel = serviceprovider.GetService<MoviesViewModel>();
            nav.mainViewModel.NavBarViewModel = serviceprovider.GetService<NavBarViewModel>();
            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();
            //base.OnStartup(e);
        }
    }
}