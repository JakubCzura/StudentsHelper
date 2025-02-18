using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advice.Application.ExtensionMethods.LayerRegistration;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationDI(this IServiceCollection services,
                                                      IConfiguration configuration)
    {
        return services;
    }
}