using System.Text.Json.Serialization;

namespace Fmd.Net.Changelog.Models;

public class ChangelogRoot
{
    [JsonPropertyName("versions")]
    public List<ChangelogVersion> Versions { get; set; }
    
    public ChangelogRoot()
    {
        Versions = new List<ChangelogVersion>();
    }
    
    public ChangelogRoot(List<ChangelogVersion> versionCollection)
    {
        Versions = versionCollection;
    }
}