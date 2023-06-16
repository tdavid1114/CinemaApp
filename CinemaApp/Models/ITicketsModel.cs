using CinemaApp.Models;
using System.Collections.ObjectModel;

namespace CinemaApp.Models
{
    public interface ITicketsModel
    {
        int CalculatePieces(int adultPieces, int studentPieces, int seniorPieces, int hendiPieces);

        int CalculatePrice(int adultPieces, int studentPieces, int seniorPieces, int hendiPieces);

        void InitializeDropdown(ObservableCollection<int> pieces);

        void NavigateToMovies();

        void NavigateToSeats();

        Movie ShowSelectedMovieData(int screeningId);
    }
}