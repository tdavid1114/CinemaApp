using CinemaApp.Models;
using CinemaApp.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace CinemaApp.Logic
{
    public class MovieLogic : IMovieLogic
    {
        //private IRepository<Movie> repository;
        private IMovieRepository repository;

        public MovieLogic(IMovieRepository repository)
        {
            this.repository = repository;
        }

        public Movie Read(int screeningId)
        {
            return this.repository.Read(screeningId);
        }

        public IEnumerable<MovieSample> ListAll()
        {
            var movies = this.repository.ReadAll()
                .Include(m => m.Languages)
                .ThenInclude(l => l.Screenings)
                .ToList();

            return from movie in movies
                   select new MovieSample()
                   {
                       Id = movie.MovieId,
                       Title = movie.Title,
                       Description = movie.Description,
                       Genre = movie.Genre,
                       AgeLimit = movie.AgeLimit,
                       MovieLength = movie.MovieLength,
                       Picture = movie.Picture,
                       Language = movie.Languages,
                       Screening = movie.Screenings,
                   };
        }

        public IEnumerable<MovieSample> ListByGenre(string genre)
        {
            return from movie in ListAll()
                   where movie.Genre.Contains(genre)
                   select movie;
        }

        public IEnumerable<string> ListGenre()
        {
            return from movie in this.repository.ReadAll()
                   select movie.Genre;
        }

        public class MovieSample
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Genre { get; set; }
            public byte AgeLimit { get; set; }
            public string MovieLength { get; set; }
            public string Picture { get; set; }
            public IEnumerable<Language> Language { get; set; }
            public IEnumerable<Screening> Screening { get; set; }
        }
    }
}