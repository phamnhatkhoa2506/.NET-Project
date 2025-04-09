namespace Admin.Models;

public partial class Booking
{
    public Guid Id { get; set; }

    public Guid ShowtimeId { get; set; }

    public Guid TransactionId { get; set; }

    public Guid ConcessionBookedId { get; set; }

    public Guid TicketBookedId { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ConcessionBooked ConcessionBooked { get; set; } = null!;

    public virtual ICollection<SeatBooked> SeatBookeds { get; set; } = new List<SeatBooked>();

    public virtual Showtime Showtime { get; set; } = null!;

    public virtual TicketBooked TicketBooked { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
