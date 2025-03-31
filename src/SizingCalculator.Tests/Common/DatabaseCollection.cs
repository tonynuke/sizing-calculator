namespace SizingCalculator.Tests.Common;

[CollectionDefinition(Name)]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    public const string Name = "DatabaseCollection";
}
