using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private CinemaDBContext ctx;

        public TicketRepository(CinemaDBContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(string title, string day, string time, int row, int column, string user)
        {
            Ticket ticket = new Ticket();
            ticket.Seatrow = (short)row;
            ticket.Seatcolumn = (short)column;
            ticket.Username = user;
            ticket.Title = title;
            ticket.Screeningday = day;
            ticket.Screeningtime = time;
            this.ctx.Tickets.Add(ticket);
            ctx.SaveChanges();
        }

        public IQueryable<Ticket> ReadAll()
        {
            return ctx.Set<Ticket>();
        }
    }
}