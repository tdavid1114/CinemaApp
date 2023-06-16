using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaApp.Models;

public partial class Screening
{
    public byte ScreeningId { get; set; }

    public string ScreeningTime { get; set; } = null!;

    public byte LanguageId { get; set; }

    public int MovieId { get; set; }

    public int SeatsId { get; set; }

    public string ScreeningDay { get; set; }

    [JsonIgnore]
    public virtual Language Language { get; set; } = null!;

    [JsonIgnore]
    public virtual Movie Movie { get; set; } = null!;

    [JsonIgnore]
    public virtual Seat Seats { get; set; } = null!;
}