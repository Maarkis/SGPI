using Microsoft.EntityFrameworkCore;

namespace SGPI.Application.Infrastructure.Database;

public static class NpgSqlConfigurator
{
    public static IServiceCollection AddNpgSql(this IServiceCollection services, string? connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));

        services.UseNpgSql(connectionString);
        services.AddHealthChecksNpgSql(connectionString);

        return services;
    }

    private static void UseNpgSql(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IAppDatabaseContext, AppDatabaseContext>((sp, options) =>
        {
            var timeProvider = sp.GetRequiredService<TimeProvider>();
            options.AddInterceptors(new AuditableEntityInterceptor(timeProvider));
            options.UseNpgsql(connectionString);
        });
    }

    private static void AddHealthChecksNpgSql(this IServiceCollection services, string connectionString)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(connectionString);
    }
}