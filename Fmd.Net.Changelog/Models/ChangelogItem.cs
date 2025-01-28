using System.Text.Json.Serialization;

namespace Fmd.Net.Changelog.Models;

public class ChangelogItem
{
    [JsonPropertyName("type")]
    public string Type { get; set; }  
    [JsonPropertyName("icon")]
    public string Icon { get; set; }
    [JsonPropertyName("label")]
    public string Label { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("details")]
    public string Details { get; set; }
}