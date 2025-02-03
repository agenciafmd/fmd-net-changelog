namespace Fmd.Net.Changelog.Factories;

public class Icon
{
    public static string GetIconForCommitType(string type)
    {
        return type switch
        {
            "feat" => "foguete",
            "fix" => "exclamacao",
            "chore" => "editar",
            "docs" => "documento",
            "security" => "trancar",
            "perf" => "foguete",
            "style" => "editar",
            _ => "editar"
        };
    }
}