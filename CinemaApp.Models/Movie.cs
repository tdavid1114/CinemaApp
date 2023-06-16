using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaApp.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public byte AgeLimit { get; set; }

    public string MovieLength { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Picture { get; set; } = null!;

    //[JsonIgnore]
    public virtual ICollection<Language> Languages { get; } = new List<Language>();

    //[JsonIgnore]
    public virtual ICollection<Screening> Screenings { get; } = new List<Screening>();
}