using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaApp.Models;

public partial class Language
{
    public byte LanguageId { get; set; }

    public string Language1 { get; set; } = null!;

    public int MovieId { get; set; }

    [JsonIgnore]
    public virtual Movie Movie { get; set; } = null!;

    //[JsonIgnore]
    public virtual ICollection<Screening> Screenings { get; } = new List<Screening>();
}