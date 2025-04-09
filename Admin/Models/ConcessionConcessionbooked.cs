namespace Admin.Models;

public partial class ConcessionConcessionbooked
{
    public Guid Id { get; set; }

    public Guid ConcessionId { get; set; }

    public Guid ConcessionBookedId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Concession Concession { get; set; } = null!;

    public virtual ConcessionBooked ConcessionBooked { get; set; } = null!;
}
