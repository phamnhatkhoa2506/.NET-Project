namespace Admin.Models;

public partial class TicketBooked
{
    public Guid Id { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual ICollection<TicketTicketbooked> TicketTicketbookeds { get; set; } = new List<TicketTicketbooked>();
}
