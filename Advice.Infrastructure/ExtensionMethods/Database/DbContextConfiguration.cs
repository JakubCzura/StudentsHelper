using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Advice.Domain.SettingsOptions.Database;
using Advice.Infrastructure.Persistence.DatabaseContext;

namespace Advice.Infrastructure.ExtensionMethods.Database;

public static class DbContextConfiguration
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services,
                                                        IConfiguration configuration)
    {
        DatabaseOptions databaseOptions = configuration.GetSection(DatabaseOptions.AppsettingsKey).Get<DatabaseOptions>()!;

        services.AddDbContext<AdviceDbContext>(options =>
            options.UseMongoDB(databaseOptions.ConnectionString, databaseOptions.DatabaseName));

        return services;
    }
}