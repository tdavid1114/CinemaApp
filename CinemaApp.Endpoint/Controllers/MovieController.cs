using CinemaApp.Logic;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.Logic.MovieLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieLogic movieLogic;

        public MovieController(IMovieLogic movieLogic)
        {
            this.movieLogic = movieLogic;
        }

        [HttpGet("{screeningId}")]
        public Movie Read(int screeningId)
        {
            return this.movieLogic.Read(screeningId);
        }

        [HttpGet]
        public IEnumerable<MovieSample> ListAll()
        {
            return this.movieLogic.ListAll();
        }

        [HttpGet("{genre}")]
        public IEnumerable<MovieSample> ListByGenre(string genre)
        {
            return this.movieLogic.ListByGenre(genre);
        }

        [HttpGet]
        public IEnumerable<string> ListGenre()
        {
            return this.movieLogic.ListGenre();
        }
    }
}