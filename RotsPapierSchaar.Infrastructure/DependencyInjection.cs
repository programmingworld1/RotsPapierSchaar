using Microsoft.Extensions.DependencyInjection;
using RotsPapierSchaar.Application.InfraServices;
using RotsPapierSchaar.Infrastructure.Generators;
using RotsPapierSchaar.Infrastructure.Repositories;

namespace RotsPapierSchaar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IComputerZetGenerator, ComputerZetGenerator>();
        services.AddSingleton<ISpelRepository, InMemorySpelRepository>();
        return services;
    }
}
