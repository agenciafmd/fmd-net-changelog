namespace Fmd.Net.Changelog.Configurations;

public class ChangelogOptions
{
    public string JsonPath { get; set; } = "changelog.json";
    public string Route { get; set; } = "/changelog";
}