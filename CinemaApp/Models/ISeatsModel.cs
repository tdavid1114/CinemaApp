using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CinemaApp.Models
{
    public interface ISeatsModel
    {
        void GetSeatsStatus(ObservableCollection<ObservableCollection<int>> Seats_y, ObservableCollection<int> Seats_x, int screeningId);

        void NavigateToPay(int screeningId, Dictionary<int, List<int>> Row);

        void NavigateToTickets();

        void CreateTicket();
    }
}