using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace SizingCalculator.Persistence;

public static class ServiceCollectionExtensions
{
    public static NpgsqlDataSource GetSource(string conectionString)
    {
        return new NpgsqlDataSourceBuilder(conectionString)
            .EnableDynamicJson()
            .BuildMultiHost()
            .WithTargetSession(TargetSessionAttributes.Primary);
    }

    public static IServiceCollection ConfigurePersistence(this IServiceCollection services, string conectionString)
    {
        var source = GetSource(conectionString);

        services.AddPooledDbContextFactory<ApplicationDbContext>(optionsAction =>
        {
            optionsAction.UseSnakeCaseNamingConvention();
            optionsAction.UseNpgsql(source);
        });

        return services;
    }
}
