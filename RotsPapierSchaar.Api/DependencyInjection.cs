using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using RotsPapierSchaar.Api.Middlewares;
using RotsPapierSchaar.Api.Validators;

namespace RotsPapierSchaar;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(DependencyInjection).Assembly);
        services.AddControllers();
        services.AddValidatorsFromAssemblyContaining<StartSpelRequestValidator>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddScoped<BusinessProblemDetailsFactory>();
        services.AddOpenApi();
        return services;
    }
}
