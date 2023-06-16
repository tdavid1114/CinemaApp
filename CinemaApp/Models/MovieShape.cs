using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CinemaApp.Models
{
    public class MovieShape
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public byte AgeLimit { get; set; }
        public string MovieLength { get; set; }
        public string Picture { get; set; }

        public Dictionary<string, List<Dictionary<string, int>>> LanguageStart { get; set; }

        public MovieShape(int id, string title, string description, string genre, byte agelimit, string movieLength, string picture, Dictionary<string, List<Dictionary<string, int>>> languageStart)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            AgeLimit = agelimit;
            MovieLength = movieLength;
            LanguageStart = languageStart;
            Picture = picture;
        }
    }
}