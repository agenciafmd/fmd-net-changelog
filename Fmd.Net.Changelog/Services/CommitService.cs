using System.Diagnostics;
using Fmd.Net.Changelog.Configurations;
using Fmd.Net.Changelog.Factories;
using Fmd.Net.Changelog.Models;

namespace Fmd.Net.Changelog.Services;

public class CommitService : ICommitService
{
    private readonly ChangelogOptions _options;

    public CommitService(ChangelogOptions options)
    {
        _options = options;
    }

    public ChangelogRoot GetChangelog()
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "log --pretty=format:\"%H|%ai|%s\"",
                WorkingDirectory = _options.RepositoryPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo);
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var commits = output.Split('\n')
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new CommitMessage
                    {
                        Hash = parts[0],
                        Date = DateTime.Parse(parts[1]).ToString("dd/MM/yyyy"),
                        Message = parts[2]
                    };
                })
                .ToList();

            return GenerateCommitRoot(commits);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter mensagens dos commits", ex);
        }
    }

    private ChangelogRoot GenerateCommitRoot(IEnumerable<CommitMessage> commitCollection)
    {
        var commitCollectionGroupedByDate = commitCollection.GroupBy(c => c.Date);
        var changelogVersionCollection = new List<ChangelogVersion>();
        foreach (var commit in commitCollectionGroupedByDate)
        {
            var changelogVersion = new ChangelogVersion
            {
                Date = commit.Key,
                Changes = commit.Select(commitMessage => new ChangelogItem
                {
                    Type = CommitInfo.GetTypeFromCommit(commitMessage.Message),
                    Description = CommitInfo.GetDescriptionFromCommit(commitMessage.Message),
                    Icon = Icon.GetIconForCommitType(CommitInfo.GetTypeFromCommit(commitMessage.Message)),
                    Label = Label.GetLabelForCommitType(CommitInfo.GetTypeFromCommit(commitMessage.Message))
                }).ToList()
            };
            changelogVersionCollection.Add(changelogVersion);
        }

        var changelogRoot = new ChangelogRoot(changelogVersionCollection);
        return changelogRoot;
    }
    
}