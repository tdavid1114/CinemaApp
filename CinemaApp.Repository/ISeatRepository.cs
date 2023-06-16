using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public interface ISeatRepository
    {
        IQueryable<Seat> ReadAll();
        void Update(int row, int column, int screeningId);
    }
}