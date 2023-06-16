using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public interface IMovieRepository
    {
        Movie Read(int id);
        IQueryable<Movie> ReadAll();
    }
}