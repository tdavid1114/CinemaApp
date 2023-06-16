using CinemaApp.Logic;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CinemaApp.Models
{
    public class MoviesModel : IMoviesModel
    {
        private IMessenger messenger;
        private RestHelper helper;

        public Dictionary<string, List<Dictionary<string, int>>> languageStart { get; set; }

        public string language { get; set; }

        public BindingList<MovieShape> movies { get; set; }

        public List<Dictionary<string, int>> start { get; set; }

        public Dictionary<string, int> stsc { get; set; }

        public MovieShape movie { get; set; }

        public List<string> genres { get; set; }

        public string selectedDay;

        public MoviesModel(IMessenger messenger, RestHelper helper)
        {
            this.messenger = messenger;
            this.helper = helper;

            movies = new BindingList<MovieShape>();
            languageStart = new Dictionary<string, List<Dictionary<string, int>>>();
            start = new List<Dictionary<string, int>>();

            var movieGenre = helper.ListGenre();
            genres = new List<string>();

            for (int i = 0; i < movieGenre.Count; i++)
            {
                var x = movieGenre[i].Split(", ");
                genres.AddRange(x);
            }

            genres = genres.Distinct().ToList();
            genres.Insert(0, "All");

            selectedDay = DateTime.Now.DayOfWeek.ToString();
        }

        public void SelectMovieScreening(object screeningId)
        {
            this.messenger.Send("TicketsViewModel", "vmchange");
            this.messenger.Send((int)screeningId, "moviedata");
            this.messenger.Send("TicketsViewModel", "vmchange");
        }

        public string SelectDay(object parameter, string Selectedgenre)
        {
            var x = (parameter as Image).Source.ToString();
            selectedDay = x.Substring(x.LastIndexOf("/") + 1, x.LastIndexOf("H") - (x.LastIndexOf("/") + 1));
            FilterDay(Selectedgenre);
            return "All";
        }

        public void FilterDay(string Selectedgenre)
        {
            movies.Clear();
            var items = helper.ListAll().Where(x => x.Screening.Any(x => x.ScreeningDay == selectedDay)).ToArray();
            PresentRequiredForm(items);
        }

        public void FilterGenre(string Selectedgenre)
        {
            movies.Clear();
            MovieLogic.MovieSample[] items;
            if (Selectedgenre == "All")
            {
                items = helper.ListAll().Where(x => x.Screening.Any(x => x.ScreeningDay == selectedDay)).ToArray();
            }
            else
            {
                items = helper.ListAll().Where(x => x.Screening.Any(s => s.ScreeningDay == selectedDay && x.Genre.Contains(Selectedgenre))).ToArray();
                // items = helper.ListByGenre(Selectedgenre).ToArray();
            }
            PresentRequiredForm(items);
        }

        public void PresentRequiredForm(MovieLogic.MovieSample[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                var langtime = items[i].Language.DistinctBy(x => x.Language1).ToArray();

                for (int j = 0; j < langtime.Length; j++) //végigmegy a nyelveken
                {
                    language = langtime[j].Language1;

                    for (int k = 0; k < langtime[j].Screenings.ToArray().Length; k++) //végigmegy a nyevlekhez tartozó időpontokon
                    {
                        if (!languageStart.ContainsKey(language))
                        {
                            start = new List<Dictionary<string, int>>();
                        }
                        if (langtime[j].Screenings.ToArray()[k].ScreeningDay == selectedDay && DateTime.Now.DayOfWeek.ToString() == selectedDay)
                        {
                            if (DateTime.ParseExact(langtime[j].Screenings.ToArray()[k].ScreeningTime, "HH:mm", CultureInfo.InvariantCulture) > DateTime.Now)
                            {
                                stsc = new Dictionary<string, int>();
                                stsc.Add(langtime[j].Screenings.ToArray()[k].ScreeningTime.ToString(), langtime[j].Screenings.ToArray()[k].ScreeningId);
                                start.Add(stsc);
                                start.Sort((x, y) => DateTime.Compare(DateTime.ParseExact(x.Keys.First(), "HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact(y.Keys.First(), "HH:mm", CultureInfo.InvariantCulture)));

                                if (!languageStart.ContainsKey(language))
                                {
                                    languageStart.Add(language, start);
                                }
                            }
                        }
                        else
                        {
                            if (langtime[j].Screenings.ToArray()[k].ScreeningDay == selectedDay)
                            {
                                stsc = new Dictionary<string, int>();
                                stsc.Add(langtime[j].Screenings.ToArray()[k].ScreeningTime.ToString(), langtime[j].Screenings.ToArray()[k].ScreeningId);
                                start.Add(stsc);
                                start.Sort((x, y) => DateTime.Compare(DateTime.ParseExact(x.Keys.First(), "HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact(y.Keys.First(), "HH:mm", CultureInfo.InvariantCulture)));

                                if (!languageStart.ContainsKey(language))
                                {
                                    languageStart.Add(language, start);
                                }
                            }
                        }
                    }
                }

                string basePath = Path.GetFullPath("Icons");
                string savePath = Path.Combine(basePath, items[i].Id + ".jpg");

                using (WebClient client = new WebClient())
                {
                    if (!File.Exists("Icons/" + items[i].Id + ".jpg"))
                    {
                        client.DownloadFile(items[i].Picture, savePath);
                    }
                }
                movie = new MovieShape(items[i].Id, items[i].Title.ToUpper(), items[i].Description, items[i].Genre, items[i].AgeLimit, items[i].MovieLength, savePath, languageStart);
                movies.Add(movie);
                languageStart = new Dictionary<string, List<Dictionary<string, int>>>();
            }
        }
    }
}