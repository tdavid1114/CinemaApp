using CinemaApp.Models;

namespace CinemaApp.Logic
{
    public interface IMovieLogic
    {
        IEnumerable<MovieLogic.MovieSample> ListAll();
        IEnumerable<MovieLogic.MovieSample> ListByGenre(string genre);
        IEnumerable<string> ListGenre();
        Movie Read(int screeningId);
    }
}