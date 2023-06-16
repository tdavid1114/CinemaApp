using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaApp.Models;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}