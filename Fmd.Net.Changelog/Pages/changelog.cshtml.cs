using System.Text.Json;
using Fmd.Net.Changelog.Configurations;
using Fmd.Net.Changelog.Models;
using Fmd.Net.Changelog.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fmd.Net.Changelog.Pages;

public class ChangelogModel : PageModel
{
    private ICommitService _commitService;
    private readonly ChangelogOptions _options;
    public List<ChangelogVersion> Versions { get; set; } = new();

    public string ContentPath = "/_content/Fmd.Net.Changelog";

    public ChangelogModel(ChangelogOptions options, ICommitService commitService)
    {
        _options = options;
        _commitService = commitService;
    }

    public async Task OnGetAsync()
    {
        if (_options.MessagesFromJson)
        {
            var changelog = await GetMessagesFromJsonFile();
            Versions = changelog.Versions;
        }
        else
        {
            var changelog = _commitService.GetChangelog();
            Versions = changelog.Versions;
        }
    }

    private async Task<ChangelogRoot> GetMessagesFromJsonFile()
    {
        var filePath = _options.JsonPath;
        if (!System.IO.File.Exists(filePath))
        {
            throw new Exception("Changelog file not found.");
        }

        var json = await System.IO.File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<ChangelogRoot>(json);
    }

    
}