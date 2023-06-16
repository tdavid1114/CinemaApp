using CinemaApp.Models;
using CinemaApp.Repository;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace CinemaApp.Logic
{
    public class TicketLogic : ITicketLogic
    {
        private ITicketRepository repository;

        public TicketLogic(ITicketRepository repository)
        {
            this.repository = repository;
        }

        public void CreateTicket(string title, string day, string time, int row, int column, string user)
        {
            this.repository.Create(title, day, time, row, column, user);
        }

        public IEnumerable<Ticket> ReadTicket(string currentuser)
        {
            return this.repository.ReadAll().Where(x => x.Username == currentuser);
        }
    }
}