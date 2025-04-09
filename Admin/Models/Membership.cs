namespace Admin.Models;

public partial class Membership
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int Point { get; set; }

    public virtual User User { get; set; } = null!;
}
