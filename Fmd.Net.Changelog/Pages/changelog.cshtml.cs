using System.Text.Json;
using Fmd.Net.Changelog.Configurations;
using Fmd.Net.Changelog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fmd.Net.Changelog.Pages;

public class ChangelogModel : PageModel
{
    private readonly ChangelogOptions _options;
    public List<ChangelogVersion> Versions { get; set; } = new();

    public string ContentPath = "/_content/Fmd.Net.Changelog";

    public ChangelogModel(ChangelogOptions options)
    {
        _options = options;
    }

    public async Task OnGetAsync()
    {
        var filePath = _options.JsonPath;
        if (!System.IO.File.Exists(filePath))
        {
            throw new Exception("Changelog file not found.");
        }

        var json = await System.IO.File.ReadAllTextAsync(filePath);
        var result = JsonSerializer.Deserialize<ChangelogRoot>(json);

        if (result != null)
        {
            Versions = result.Versions;
        }
    }

    public string GetBadgeClass(string type) => type.ToLower() switch
    {
        "added" => "badge-success",
        "changed" => "badge-warning",
        "security" => "badge-security",
        "fix" => "badge-fix",
        _ => "badge-secondary"
    };
}