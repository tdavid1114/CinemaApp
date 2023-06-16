using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class TicketsViewModel : ViewModelBase
    {
        private ITicketsModel ticketsModel;

        private IMovieLogic movieLogic { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int AgeLimit { get; set; }
        public string MovieLength { get; set; }
        public string Language { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }

        public ObservableCollection<int> Pieces { get; private set; }

        private int selectedAdultTicket;

        public int SelectedAdultTicket
        {
            get { return selectedAdultTicket; }
            set { Set(ref selectedAdultTicket, value); }
        }

        private int selectedStudentTicket;

        public int SelectedStudentTicket
        {
            get { return selectedStudentTicket; }
            set { Set(ref selectedStudentTicket, value); }
        }

        private int selectedSeniorTicket;

        public int SelectedSeniorTicket
        {
            get { return selectedSeniorTicket; }
            set { Set(ref selectedSeniorTicket, value); }
        }

        private int selectedHandiTicket;

        public int SelectedHandiTicket
        {
            get { return selectedHandiTicket; }
            set { Set(ref selectedHandiTicket, value); }
        }

        private int piecesSelected;

        public int PiecesSelected
        {
            get { return piecesSelected; }
            set { Set(ref piecesSelected, value); }
        }

        private int totalPrice;

        public int TotalPrice
        {
            get { return totalPrice; }
            set { Set(ref totalPrice, value); }
        }

        public static int screeningId;
        public ICommand GoToMovies { get; private set; }
        public ICommand GoToSeats { get; private set; }
        public ICommand SelectAmount { get; private set; }

        public TicketsViewModel(ITicketsModel ticketsModel)
        {
            this.ticketsModel = ticketsModel;
            Pieces = new ObservableCollection<int>();

            this.ticketsModel.InitializeDropdown(Pieces);
            SelectAmount = new RelayCommand(() =>
            {
                PiecesSelected = this.ticketsModel.CalculatePieces(SelectedAdultTicket, SelectedStudentTicket, SelectedSeniorTicket, SelectedHandiTicket);
                TotalPrice = this.ticketsModel.CalculatePrice(SelectedAdultTicket, SelectedStudentTicket, SelectedSeniorTicket, SelectedHandiTicket);
            });
            GoToSeats = new RelayCommand(() => this.ticketsModel.NavigateToSeats());
            GoToMovies = new RelayCommand(() => this.ticketsModel.NavigateToMovies());

            Messenger.Default.Register<int>(this, "moviedata", msg =>
            {
                screeningId = msg;
            });
            if (screeningId != 0)
            {
                var selectedMovie = this.ticketsModel.ShowSelectedMovieData(screeningId);

                Title = selectedMovie.Title;
                Genre = selectedMovie.Genre;
                AgeLimit = selectedMovie.AgeLimit;
                MovieLength = selectedMovie.MovieLength;
                Time = selectedMovie.Screenings.Where(x => x.ScreeningId == screeningId).Select(x => x.ScreeningTime).FirstOrDefault();
                Language = selectedMovie.Languages.Where(x => x.Screenings.Any(x => x.ScreeningId == screeningId)).Select(x => x.Language1).FirstOrDefault();

                DateTime today = DateTime.Today;
                int daysUntilScreeningDay = ((int)(DayOfWeek)Enum.Parse(typeof(DayOfWeek), selectedMovie.Screenings.Where(x => x.ScreeningId == screeningId).Select(x => x.ScreeningDay).FirstOrDefault()) - (int)today.DayOfWeek + 7) % 7;
                Date = today.AddDays(daysUntilScreeningDay).ToString("yyyy.MM.dd");
            }
        }
    }
}