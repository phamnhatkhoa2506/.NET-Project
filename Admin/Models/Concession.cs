using System.Text.Json;
using System.Text.Json.Serialization;

namespace Admin.Models;

public partial class Concession : NameBase
{
    [JsonIgnore]
    public Guid ConcessionTypeId { get; set; }

    public decimal Price { get; set; }

    public string? ImgUrl { get; set; }

    public int Quantity { get; set; }

    [JsonIgnore]
    public virtual ICollection<ConcessionConcessionbooked> ConcessionConcessionbookeds { get; set; } = new List<ConcessionConcessionbooked>();

    public virtual ConcessionType ConcessionType { get; set; } = null!;
}
