using System.Text.Json.Serialization;

namespace BackEnd.Models;

public class NameBase
{
    [JsonPropertyOrder(-3)]
    public Guid? Id { get; set; }

    [JsonPropertyOrder(-2)]
    public string NameVn { get; set; } = null!;

    [JsonPropertyOrder(-1)]
    public string NameEn { get; set; } = null!;
}

public partial class Area : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();
}

public partial class ConcessionType : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Concession> Concessions { get; set; } = new List<Concession>();
}

public partial class Country : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

public partial class Format : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

public partial class Genre : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

public partial class Language : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

public partial class LimitAge : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

public partial class SeatType : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}

public partial class TicketType : NameBase
{
    [JsonIgnore]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
