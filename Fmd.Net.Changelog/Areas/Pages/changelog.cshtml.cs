using System.Text.Json;
using Fmd.Net.Changelog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fmd.Net.Changelog.Areas.Pages;

public class ChangelogModel : PageModel
{
    private readonly IWebHostEnvironment _env;
    public List<ChangelogVersion> Versions { get; set; } = new();

    public ChangelogModel(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task OnGetAsync()
    {
        var filePath = Path.Combine(_env.WebRootPath, "json", "changelog.json");
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
