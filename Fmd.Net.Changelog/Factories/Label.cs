namespace Fmd.Net.Changelog.Factories;

public class Label
{
    public static string GetLabelForCommitType(string type)
    {
        return type switch
        {
            "feat" => "NOVIDADE",
            "fix" => "CORREÇÃO",
            "chore" => "ALTERAÇÃO",
            "docs" => "DOCUMENTAÇÃO",
            "security" => "SEGURANÇA",
            "perf" => "PERFORMANCE",
            _ => "ALTERAÇÃO"
        };
    }
}