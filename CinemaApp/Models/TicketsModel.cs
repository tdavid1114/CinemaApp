using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;
using CinemaApp.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class TicketsModel : ITicketsModel
    {
        private IMessenger messenger;
        public int totalPieces;
        public int totalPrice;
        private RestHelper helper;

        public TicketsModel(IMessenger messenger, RestHelper helper)
        {
            this.messenger = messenger;
            this.helper = helper;
        }

        public int CalculatePieces(int adultPieces, int studentPieces, int seniorPieces, int hendiPieces)
        {
            totalPieces = adultPieces + studentPieces + seniorPieces + hendiPieces;
            this.messenger.Send(totalPieces, "ticketdata");
            return totalPieces;
        }

        public int CalculatePrice(int adultPieces, int studentPieces, int seniorPieces, int hendiPieces)
        {
            totalPrice = 5 * adultPieces + 4 * studentPieces + 4 * seniorPieces + 4 * hendiPieces;
            //
            return totalPrice;
        }

        public void NavigateToSeats()
        {
            this.messenger.Send("SeatsViewModel", "vmchange");
        }

        public void NavigateToMovies()
        {
            this.messenger.Send("MoviesViewModel", "vmchange");
        }

        public void InitializeDropdown(ObservableCollection<int> pieces)
        {
            for (int i = 0; i < 10; i++)
            {
                pieces.Add(i);
            }
        }

        public Movie ShowSelectedMovieData(int screeningId)
        {
            return helper.GetSelectedMovie(screeningId);
        }
    }
}