using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CinemaApp.Models;

public partial class Ticket
{
    public short Ticketsid { get; set; }

    public string Title { get; set; } = null!;

    public string Screeningday { get; set; } = null!;

    public string Screeningtime { get; set; } = null!;

    public short Seatrow { get; set; }

    public short Seatcolumn { get; set; }

    public string Username { get; set; } = null!;

    [JsonIgnore]
    public virtual Account UsernameNavigation { get; set; } = null!;
}