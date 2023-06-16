using CinemaApp.Logic;
using CinemaApp.Repository;
using CinemaApp.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace CinemaApp.Models
{
    public class SeatsModel : ISeatsModel
    {
        private IMessenger messenger;
        private RestHelper helper;

        public SeatsModel(IMessenger messenger, RestHelper helper)
        {
            this.messenger = messenger;
            this.helper = helper;
        }

        public void GetSeatsStatus(ObservableCollection<ObservableCollection<int>> Seats_y, ObservableCollection<int> Seats_x, int screeningId)
        {
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 11; i++)
                {
                    if (screeningId != 0)
                    {
                        Seats_x.Add(helper.ReadSeats(screeningId)[j][i]);
                    }
                }
                Seats_y.Add(Seats_x);
                Seats_x = new ObservableCollection<int>();
            }
        }

        public void NavigateToTickets()
        {
            this.messenger.Send("TicketsViewModel", "vmchange");
        }

        public void NavigateToPay(int screeningId, Dictionary<int, List<int>> Row)
        {
            foreach (KeyValuePair<int, List<int>> pair in Row)
            {
                foreach (var value in pair.Value)
                {
                    helper.UpdateSeats(pair.Key, value, screeningId);
                    var movie = helper.GetSelectedMovie(screeningId);
                    var time = movie.Screenings.Where(x => x.ScreeningId == screeningId).Select(x => x.ScreeningTime).FirstOrDefault();
                    DateTime today = DateTime.Today;
                    int daysUntilScreeningDay = ((int)(DayOfWeek)Enum.Parse(typeof(DayOfWeek), movie.Screenings.Where(x => x.ScreeningId == screeningId).Select(x => x.ScreeningDay).FirstOrDefault()) - (int)today.DayOfWeek + 7) % 7;
                    var day = today.AddDays(daysUntilScreeningDay).ToString("yyyy.MM.dd");
                    helper.CreateTicket(movie.Title, day, time, (short)pair.Key + 1, (short)value + 1, LoginViewModel.currentUser);
                }
            }
            this.messenger.Send("MoviesViewModel", "vmchange");
        }

        public void CreateTicket()
        {
        }
    }
}