using Microsoft.Extensions.DependencyInjection;
using RotsPapierSchaar.Application.ApplicationServices;
using RotsPapierSchaar.Application.Services;

namespace RotsPapierSchaar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISpelService, SpelService>();
        return services;
    }
}
