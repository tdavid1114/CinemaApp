using CinemaApp.Logic;
using System.Collections.Generic;
using System.ComponentModel;

namespace CinemaApp.Models
{
    public interface IMoviesModel
    {
        List<string> genres { get; set; }
        string language { get; set; }
        Dictionary<string, List<Dictionary<string, int>>> languageStart { get; set; }
        MovieShape movie { get; set; }
        BindingList<MovieShape> movies { get; set; }
        List<Dictionary<string, int>> start { get; set; }
        Dictionary<string, int> stsc { get; set; }

        void FilterDay(string Selectedgenre);

        void FilterGenre(string Selectedgenre);

        void PresentRequiredForm(MovieLogic.MovieSample[] items);

        string SelectDay(object parameter, string Selectedgenre);

        void SelectMovieScreening(object screeningId);
    }
}