namespace Client.Models;

public partial class Showtime
{
    public Guid Id { get; set; }

    public Guid MovieId { get; set; }

    public int RoomId { get; set; }

    public DateOnly DateShow { get; set; }

    public TimeOnly StartTime { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Movie Movie { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
