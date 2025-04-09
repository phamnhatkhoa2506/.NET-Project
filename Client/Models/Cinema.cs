using System.Text.Json.Serialization;

namespace Client.Models;

public partial class Cinema : NameBase
{
    [JsonIgnore]
    public Guid AreaId { get; set; }

    public string Address { get; set; } = null!;

    public int NumRooms { get; set; }

    public virtual Area Area { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
