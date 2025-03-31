using Microsoft.Extensions.DependencyInjection;
using SizingCalculator.Application.DataSchemas;

namespace SizingCalculator.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        var assembly = typeof(CreateDataSchema).Assembly;
        services.AddMediatR(x => x.RegisterServicesFromAssembly(assembly));

        return services;
    }
}
