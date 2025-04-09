namespace Client.Models;

public partial class TicketTicketbooked
{
    public Guid Id { get; set; }

    public Guid TicketId { get; set; }

    public Guid TicketBookedId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual TicketBooked TicketBooked { get; set; } = null!;
}
