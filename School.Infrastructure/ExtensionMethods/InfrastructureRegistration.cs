using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Application.ExtensionMethods.LayerRegistration;

namespace School.Infrastructure.ExtensionMethods;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,
                                                         IConfiguration configuration)
    {
        services.AddApplicationDI(configuration);

        return services;
    }
}