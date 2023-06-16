using Castle.Components.DictionaryAdapter;
using CinemaApp.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.ViewModels
{
    public class MyTicketsViewModel : ViewModelBase
    {
        public ObservableCollection<Ticket> TicketInfo { get; set; }

        private IMyTicketsModel myTicketsModel;

        public MyTicketsViewModel(IMyTicketsModel myTicketsModel)
        {
            this.myTicketsModel = myTicketsModel;
            if (LoginViewModel.currentUser != null)
            {
                TicketInfo = this.myTicketsModel.ListMyTickets(LoginViewModel.currentUser);
            }
        }
    }
}