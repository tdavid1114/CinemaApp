using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public interface ITicketRepository
    {
        void Create(string title, string day, string time, int row, int column, string user);
        IQueryable<Ticket> ReadAll();
    }
}