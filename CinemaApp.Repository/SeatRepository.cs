using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private CinemaDBContext ctx;

        public SeatRepository(CinemaDBContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<Seat> ReadAll()
        {
            return ctx.Set<Seat>();
        }

        public void Update(int row, int column, int screeningId)
        {
            var seat = ctx.Seats.FirstOrDefault(x => x.Screenings.Any(x => x.ScreeningId == screeningId));
            seat.AvailableSeats[row, column] = 2;
            ctx.Entry(seat).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}