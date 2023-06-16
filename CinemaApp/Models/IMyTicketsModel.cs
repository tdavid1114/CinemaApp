using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CinemaApp.Models
{
    public interface IMyTicketsModel
    {
        ObservableCollection<Ticket> ListMyTickets(string currentuser);
    }
}