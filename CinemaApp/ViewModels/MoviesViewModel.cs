using CinemaApp.Commands;
using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        private IMessenger messenger;

        public BindingList<MovieShape> movies { get; set; }
        public List<string> genres { get; set; }

        private string selectedgenre;

        public string Selectedgenre
        {
            get { return selectedgenre; }
            set { Set(ref selectedgenre, value); }
        }

        public ICommand GenreFilter { get; private set; }
        public ICommand DayFilter { get; private set; }

        public ICommand SelectScreening { get; private set; }

        private IMoviesModel moviesModel;

        public MoviesViewModel(IMoviesModel moviesModel)
        {
            this.moviesModel = moviesModel;

            movies = this.moviesModel.movies;
            genres = this.moviesModel.genres;

            GenreFilter = new RelayCommand(() => this.moviesModel.FilterGenre(Selectedgenre));
            DayFilter = new RelayCommand<object>(SelectDay);
            SelectScreening = new RelayCommand<object>(this.moviesModel.SelectMovieScreening);

            moviesModel.FilterDay(Selectedgenre);
        }

        private void SelectDay(object obj)
        {
            Selectedgenre = this.moviesModel.SelectDay(obj, Selectedgenre);
        }
    }
}