using Fmd.Net.Changelog.Models;

namespace Fmd.Net.Changelog.Services;

public interface ICommitService
{
    ChangelogRoot GetChangelog();
}