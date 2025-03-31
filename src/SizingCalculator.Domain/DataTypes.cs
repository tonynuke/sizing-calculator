namespace SizingCalculator.Domain;

/// <summary>
/// Типы данных.
/// </summary>
public static class DataTypes
{
    public static DataType Integer = new DataType
    {
        Id = System.Guid.Parse("08f657c5-5fd3-4fd8-86d7-c728b51068fd"),
        Title = "integer",
        Size = 4
    };

    public static DataType Bigint = new DataType
    {
        Id = System.Guid.Parse("63050397-67f1-4916-a773-cdde27a79a93"),
        Title = "bigint",
        Size = 8
    };

    public static DataType Guid = new DataType
    {
        Id = System.Guid.Parse("8587199a-9ae0-40b4-86f8-89ff8b6b4e7f"),
        Title = "guid",
        Size = 16
    };

    public static DataType Text = new DataType
    {
        Id = System.Guid.Parse("e2a769cb-4193-4b4e-b274-97e0458de3b9"),
        Title = "text",
        Size = 4
    };

    public static DataType Timestamp => new DataType
    {
        Id = System.Guid.Parse("88ba1af1-8d2d-4cba-a616-e446a9fe078b"),
        Title = "timestamp",
        Size = 4
    };

    public static DataType Bool = new DataType
    {
        Id = System.Guid.Parse("426b7aa2-fd83-47bf-8d84-a74f7cce4eac"),
        Title = "bool",
        Size = 1
    };

    public static readonly IReadOnlyCollection<DataType> Types =
        [Integer, Bigint, Guid, Text, Timestamp, Bool];

}
