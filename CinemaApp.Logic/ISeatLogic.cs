using CinemaApp.Models;

namespace CinemaApp.Logic
{
    public interface ISeatLogic
    {
        List<List<short>> ReadSeats(int screeningsId);

        void UpdateSeats(int row, int column, int screeningsId);
    }
}