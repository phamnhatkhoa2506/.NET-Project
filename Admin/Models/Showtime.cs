using System.Text.Json.Serialization;

namespace Admin.Models;

public partial class Showtime
{
    public Guid Id { get; set; }

     [JsonIgnore]
    public Guid MovieId { get; set; }

    [JsonIgnore]
    public int RoomId { get; set; }

    public DateOnly DateShow { get; set; }

    public TimeOnly StartTime { get; set; }

    [JsonIgnore]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
   
    public virtual Movie Movie { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
