namespace Fmd.Net.Changelog.Factories;

public class CommitInfo
{
    public static string GetTypeFromCommit(string commit)
    {
        if (commit.Contains("("))
        {
            return commit.Split("(")[0].Trim();
        }

        return "feat";
    }
    
    public static string GetDescriptionFromCommit(string commit)
    {
        if (commit.Contains(":"))
        {
            return commit.Split(":")[1].Trim();
        }
        
        if (commit.Contains(")"))
        {
            return commit.Split(")")[1].Trim();
        }

        return commit;
    }
}