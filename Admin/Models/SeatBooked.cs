namespace Admin.Models;

public partial class SeatBooked
{
    public Guid BookingId { get; set; }

    public Guid SeatId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
