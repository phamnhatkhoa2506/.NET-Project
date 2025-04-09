
using BackEnd.Models;

namespace BackEnd.DTOs;

public class MovieDTO : NameBase
{
    public int Duration { get; set; }

    public string Director { get; set; } = null!;

    public string Actor { get; set; } = null!;

    public string? GenreId {get; set;} = null;

    public string? GenreNameVN {get; set;} = null;

    public string? GenreNameEN {get; set;} = null;

    public DateTime ReleasedDate { get; set; }

    public DateTime? EndDate { get; set; } = null;

    public Guid? CountryId { get; set; } = null;

    public string? CountryNameVN {get; set;} = null;

    public string? CountryNameEN {get; set;} = null;

    public Guid? LimitAgeId { get; set;} = null;

    public string? LimitAgeVN {get; set;} = null;

    public string? LimitAgeEN {get; set;} = null;

    public Guid? FormatId { get; set;} = null;

    public string? FormatVN {get; set;} = null;

    public string? FormatEN {get; set;} = null;

    public Guid? LanguageId { get; set;} = null;

    public string? LanguageVN {get; set;} = null;

    public string? LanguageEN {get; set;} = null;

    public string? BriefVN { get; set; } = null;

    public string? BriefEN { get; set; } = null;

    public int Status { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? PosterUrl { get; set; } = null;

    public string? TrailerUrl { get; set; } = null;

    public MovieDTO(
        Guid? id, 
        string nameVn, 
        string nameEn,
        int duration,
        string director,
        string actor,
        string genreNameVN,
        string genreNameEN,
        DateTime releasedDate,
        DateTime endDate,
        string briefVN,
        string briefEN,
        int status,
        string imageUrl,
        Guid? countryId,
        Guid? limitAgeId,
        Guid? formatId, 
        Guid? languageId,
        string posterUrl = "",
        string trailerUrl = "",
        string? countryNameVN = null,
        string? countryNameEN = null,
        string? limitAgeVN = null,
        string? limitAgeEN = null,
        string? formatVN = null,
        string? formatEN = null,
        string? languageVN = null,
        string? languageEN = null,
        string? genreId = null
    ) : base(id, nameVn, nameEn)
    {
        this.Duration = duration;
        this.Actor = actor;
        this.Director = director;
        this.GenreId = genreId;
        this.GenreNameVN = genreNameVN;
        this.GenreNameEN = genreNameEN;
        this.ReleasedDate = releasedDate;
        this.EndDate = endDate;
        this.CountryId = countryId;
        this.CountryNameVN = countryNameVN;
        this.CountryNameEN = countryNameEN;
        this.LimitAgeId = limitAgeId;
        this.LimitAgeVN = limitAgeVN;
        this.LimitAgeEN = limitAgeEN;
        this.FormatId = formatId;
        this.FormatVN = formatVN;
        this.FormatEN = formatEN;
        this.LanguageId = languageId;
        this.LanguageVN = languageVN;
        this.LanguageEN = languageEN;
        this.BriefVN = briefVN;
        this.BriefEN = briefEN;
        this.Status = status;
        this.ImageUrl = imageUrl;
        this.PosterUrl = posterUrl;
        this.TrailerUrl = trailerUrl;
    }

    public MovieDTO(
        Movie movie
    ) : base(movie.Id, movie.NameVn, movie.NameEn)
    {
        this.Duration = movie.Duration;
        this.Actor = movie.Actor;
        this.Director = movie.Director;
        this.ReleasedDate = movie.ReleasedDate;
        this.EndDate = movie.EndDate;
        this.CountryId = movie.CountryId;
        this.LimitAgeId = movie.LimitAgeId;
        this.FormatId = movie.FormatId;
        this.LanguageId = movie.LanguageId;
        this.BriefVN = movie.BriefVn;
        this.BriefEN = movie.BriefEn;
        this.Status = movie.Status;
        this.ImageUrl = movie.ImageUrl;
        this.PosterUrl = movie.PosterUrl;
        this.TrailerUrl = movie.TrailerUrl;
    }
}