using CinemaApp.Commands;
using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class SeatsViewModel : ViewModelBase
    {
        private ISeatsModel seatsModel;

        public ObservableCollection<ObservableCollection<int>> Seats_y { get; set; }
        public ObservableCollection<int> Seats_x { get; set; }

        public Dictionary<int, List<int>> Row = new Dictionary<int, List<int>>();

        private static int screeningId;

        private int seatsToSelect;

        public int SeatsToSelect
        {
            get { return seatsToSelect; }
            set { Set(ref seatsToSelect, value); }
        }

        public static bool loggedIn;

        private bool loggedStatus;

        public bool LoggedStatus
        {
            get { return loggedStatus; }
            set { Set(ref loggedStatus, value); }
        }

        public ICommand SeatIsSelected { get; private set; }
        public ICommand Back { get; private set; }
        public ICommand Reserve { get; private set; }

        public SeatsViewModel(ISeatsModel seatsModel)
        {
            this.seatsModel = seatsModel;
            var connection = new HubConnectionBuilder()
              .WithUrl("http://localhost:5099/hub")
              .WithAutomaticReconnect()
              .Build();

            connection.On<int, int>("SeatStatusChanged", (row, column) =>
            {
                Seats_y[row][column] = 2;
                if (Row.ContainsKey(row) && Row[row].Contains(column))
                {
                    SeatsToSelect++;
                }
            });
            connection.StartAsync();

            Seats_y = new ObservableCollection<ObservableCollection<int>>();
            Seats_x = new ObservableCollection<int>();

            this.seatsModel.GetSeatsStatus(Seats_y, Seats_x, screeningId);

            SeatIsSelected = new SeatsCommand(this);
            Back = new RelayCommand(() => this.seatsModel.NavigateToTickets());
            Reserve = new RelayCommand(() =>
            {
                this.seatsModel.NavigateToPay(screeningId, Row);
                this.seatsModel.CreateTicket();
            });

            LoggedStatus = loggedIn;

            Messenger.Default.Register<int>(this, "ticketdata", msg =>
            {
                SeatsToSelect = msg;
            });
            Messenger.Default.Register<int>(this, "moviedata", msg =>
            {
                screeningId = msg;
            });
        }
    }
}