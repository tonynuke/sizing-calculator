
using Microsoft.EntityFrameworkCore;
using SizingCalculator.Persistence;

namespace SizingCalculator.Tests.Common;

internal class DatabaseFixture : IAsyncLifetime
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public ApplicationDbContext CreateDbContext() => new(_dbContextOptions);

    public DatabaseFixture()
    {
        var connectionString = "";
        var source = Persistence.ServiceCollectionExtensions.GetSource(connectionString);

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
