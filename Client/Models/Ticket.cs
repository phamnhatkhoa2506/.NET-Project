using System.Text.Json.Serialization;

namespace Client.Models;

public partial class Ticket
{
    public Guid? Id { get; set; } = null;

    [JsonIgnore]
    public Guid TicketTypeId { get; set; }

    public decimal Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<TicketTicketbooked> TicketTicketbookeds { get; set; } = new List<TicketTicketbooked>();

    public virtual TicketType TicketType { get; set; } = null!;
}
