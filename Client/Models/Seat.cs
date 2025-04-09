using System.Text.Json.Serialization;

namespace Client.Models;

public partial class Seat
{
    public Guid Id { get; set; }

    [JsonIgnore]
    public int RoomId { get; set; }

    [JsonIgnore]
    public Guid SeatTypeId { get; set; }

    public string? SeatPos { get; set; }

    public virtual Room Room { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<SeatBooked> SeatBookeds { get; set; } = new List<SeatBooked>();

    public virtual SeatType SeatType { get; set; } = null!;
}
