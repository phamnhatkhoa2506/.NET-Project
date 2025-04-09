namespace Client.Models;
public partial class ConcessionBooked
{
    public Guid Id { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual ICollection<ConcessionConcessionbooked> ConcessionConcessionbookeds { get; set; } = new List<ConcessionConcessionbooked>();
}
