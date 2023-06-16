using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private CinemaDBContext ctx;

        public MovieRepository(CinemaDBContext ctx)
        {
            this.ctx = ctx;
        }

        public Movie Read(int id)
        {
            return (from movie in ctx.Movies
                    join start in ctx.Screenings on movie.MovieId equals start.MovieId
                    where start.ScreeningId == id
                    select movie).FirstOrDefault();
        }

        public IQueryable<Movie> ReadAll()
        {
            return ctx.Set<Movie>();
        }
    }
}