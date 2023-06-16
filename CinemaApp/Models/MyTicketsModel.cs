using CinemaApp.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class MyTicketsModel : IMyTicketsModel
    {
        private RestHelper helper;

        public MyTicketsModel(RestHelper helper)
        {
            this.helper = helper;
        }

        public ObservableCollection<Ticket> ListMyTickets(string currentuser)
        {
            return this.helper.ReadTicket(currentuser);
        }
    }
}