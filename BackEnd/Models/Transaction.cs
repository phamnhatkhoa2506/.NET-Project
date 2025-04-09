namespace BackEnd.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreateAt { get; set; }

    public string BankName { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual User User { get; set; } = null!;
}
