using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fmd.Net.Changelog.Configurations;

public static class ChangelogExtensions
{
    public static IServiceCollection AddChangelog(
        this IServiceCollection services, 
        Action<ChangelogOptions> options = null)
    {
        var changelogOptions = new ChangelogOptions();
        options?.Invoke(changelogOptions);

        services.AddRazorPages();
        services.AddSingleton(changelogOptions);
        
        return services;
    }

    public static IApplicationBuilder UseChangelog(
        this IApplicationBuilder app)
    {
        app.UseStaticFiles();
        return app;
    }
}
