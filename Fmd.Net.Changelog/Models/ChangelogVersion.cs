using System.Text.Json.Serialization;

namespace Fmd.Net.Changelog.Models;

public class ChangelogVersion
{
    [JsonPropertyName("date")]
    public string Date { get; set; }
    [JsonPropertyName("changes")]
    public List<ChangelogItem> Changes { get; set; }
}
