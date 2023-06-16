using CinemaApp.Models;

namespace CinemaApp.Logic
{
    public interface ITicketLogic
    {
        void CreateTicket(string title, string day, string time, int row, int column, string user);
        IEnumerable<Ticket> ReadTicket(string currentuser);
    }
}