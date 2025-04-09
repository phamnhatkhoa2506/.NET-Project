using System.Text.Json.Serialization;

namespace Client.Models;

public partial class Movie : NameBase
{
    [JsonIgnore]
    public Guid CountryId { get; set; }

    [JsonIgnore]
    public Guid LimitAgeId { get; set; }

    [JsonIgnore]
    public Guid FormatId { get; set; }

    [JsonIgnore]
    public Guid LanguageId { get; set; }

    public int Duration { get; set; }

    public string Director { get; set; } = null!;

    public string Actor { get; set; } = null!;

    public DateTime ReleasedDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? BriefVn { get; set; }

    public string? BriefEn { get; set; }

    public int Status { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? PosterUrl { get; set; } = null;

    public string? TrailerUrl { get; set; } = null;

    public virtual Country Country { get; set; } = null!;

    public virtual Format Format { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;

    public virtual LimitAge LimitAge { get; set; } = null!;

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
