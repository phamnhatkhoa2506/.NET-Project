using System.Text.Json.Serialization;

namespace BackEnd.Models;

public partial class SeatBooked
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public Guid BookingId { get; set; }

    public Guid SeatId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
