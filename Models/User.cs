using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace practicando.Models;

public class User
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

