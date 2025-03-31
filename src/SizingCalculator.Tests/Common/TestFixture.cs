using SizingCalculator.Application;
using SizingCalculator.Persistence;

namespace SizingCalculator.Tests.Common;

internal static class TestFixture
{
    public static IServiceCollection ConfigureTest()
    {
        return new ServiceCollection()
            .ConfigurePersistence(DatabaseFixture.ConnectionString)
            .ConfigureApplication();
    }
}
