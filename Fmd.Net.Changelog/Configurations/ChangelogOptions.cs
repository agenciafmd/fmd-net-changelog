namespace Fmd.Net.Changelog.Configurations;

public class ChangelogOptions
{
    public string JsonPath { get; set; } = "changelog.json";
    public string RepositoryPath { get; set; }
    public bool MessagesFromJson { get; set; } = false;
}