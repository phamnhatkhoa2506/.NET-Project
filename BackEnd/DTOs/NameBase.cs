
using System.Text.Json.Serialization;

namespace BackEnd.DTOs;

public class NameBase
{
    [JsonPropertyOrder(-3)]
    public Guid? ID {get; set;}

    [JsonPropertyOrder(-2)]
    public string NameVN {get; set;}

    [JsonPropertyOrder(-1)]
    public string NameEN {get; set;}

    public NameBase(Guid? id, string nameVn, string nameEn)
    {
        this.ID = id;
        this.NameVN = nameVn;
        this.NameEN = nameEn;
    }
}