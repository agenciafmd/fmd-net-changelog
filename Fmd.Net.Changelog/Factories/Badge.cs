namespace Fmd.Net.Changelog.Factories;

public class Badge
{
    public static string GetBadgeClass(string type) => type.ToLower() switch
    {
        "feat" => "badge-success",
        "fix" => "badge-fix",
        "chore" => "badge-warning",
        "docs" => "badge-warning",
        "security" => "badge-security",
        "perf" => "badge-success",
        "style" => "badge-warning",
        _ => "badge-secondary"
    };
}