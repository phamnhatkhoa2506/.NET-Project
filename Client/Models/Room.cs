using System.Text.Json.Serialization;

namespace Client.Models;

public partial class Room
{
    public int Id { get; set; }

    [JsonIgnore]
    public Guid? CinemaId { get; set; }

    public string? RoomType { get; set; }

    public int NumSeats { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    [JsonIgnore]
    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
