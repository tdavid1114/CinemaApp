using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaApp.Models;

public partial class Seat
{
    public int SeatsId { get; set; }

    public short[,] AvailableSeats { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}