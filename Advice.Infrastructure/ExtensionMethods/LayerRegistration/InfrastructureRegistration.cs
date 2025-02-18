using Advice.Application.ExtensionMethods.LayerRegistration;
using Advice.Application.Interfaces.Persistence.Repositories;
using Advice.Infrastructure.ExtensionMethods.Database;
using Advice.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advice.Infrastructure.ExtensionMethods.LayerRegistration;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,
                                                         IConfiguration configuration)
    {
        services.AddApplicationDI(configuration);

        services.ConfigureDbContext(configuration);

        services.AddScoped<IQuickTipRepository, QuickTipRepository>();

        return services;
    }
}