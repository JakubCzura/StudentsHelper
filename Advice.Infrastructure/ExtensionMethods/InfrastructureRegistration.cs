using Advice.Application.ExtensionMethods.LayerRegistration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advice.Infrastructure.ExtensionMethods;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,
                                                         IConfiguration configuration)
    {
        services.AddApplicationDI(configuration);

        return services;
    }
}