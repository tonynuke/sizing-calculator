
using Microsoft.EntityFrameworkCore;
using SizingCalculator.Persistence;

namespace SizingCalculator.Tests.Common;

internal class DatabaseFixture : IAsyncLifetime
{
    public const string ConnectionString = "Host=localhost;Database=sizing_calculator;Username=postgres;Password=postgres";

    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public ApplicationDbContext CreateDbContext() => new(_dbContextOptions);

    public DatabaseFixture()
    {
        var source = Persistence.ServiceCollectionExtensions.GetSource(ConnectionString);

        _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(source)
            .UseSnakeCaseNamingConvention().EnableSensitiveDataLogging().Options;
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task InitializeAsync()
    {
        await using var dbContext = CreateDbContext();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }
}
