namespace SizingCalculator.Domain.Persistence;

public static class Adviser
{
    public static readonly long Terabyte = (long)Math.Pow(2, 40);
    public static readonly long Gigabyte = (long)Math.Pow(2, 30);
    public static readonly long Megabyte = (long)Math.Pow(2, 20);

    private static readonly List<Database> _databases = [];

    public static readonly Database Postgres = new Database
    {
        Name = "Postgres",
        IsShardingAvailable = false,
        MaxColumnSize = Gigabyte,
        MaxRowSize = 1.6 * Terabyte,
        MaxTableSize = 32 * Terabyte,
        IsTranasctional = true,
    };

    public static readonly Database MongoDb = new Database
    {
        Name = "MongoDb",
        IsShardingAvailable = true,
        MaxColumnSize = null,
        MaxRowSize = 16 * Megabyte,
        MaxTableSize = null,
        IsTranasctional = false,
    };

    public static readonly Database Cassandra = new Database
    {
        Name = "Cassandra",
        IsShardingAvailable = true,
        MaxColumnSize = 2 * Gigabyte,
        MaxRowSize = null,
        MaxTableSize = null,
        IsTranasctional = false,
    };

    public static readonly Database ClickHouse = new Database
    {
        Name = "ClickHouse",
        IsShardingAvailable = true,
        MaxColumnSize = null,
        MaxRowSize = null,
        MaxTableSize = 150 * Gigabyte,
        IsTranasctional = false,
    };

    static Adviser()
    {
        _databases.Add(Postgres);
        _databases.Add(MongoDb);
        _databases.Add(Cassandra);
        _databases.Add(ClickHouse);
    }

    public static IReadOnlyCollection<string> GetAdvices(AdviceRequest request)
    {
        List<string> advices = [];

        if (request.Sizing.TotalSize > Postgres.MaxTableSize)
        {
            advices.Add("Максимальный размер таблицы в Postgres 32 TB. Рассмотрите партицирование.");
        }

        if (request.Sizing.RowSize > Postgres.MaxRowSize)
        {
            advices.Add("Максимальный размер строки в Postgres 1.6 TB.");
        }

        if (request.Sizing.RowSize > MongoDb.MaxRowSize)
        {
            advices.Add("Максимальный размер документа в MongoDB 16 MB. Рассмотрите GridFS.");
        }

        if (request.Sizing.RowSize > Cassandra.MaxColumnSize)
        {
            advices.Add("Максимальный размер колонки в Cassandra 2 GB.");
        }

        if (request.IsConsistent)
        {
            advices.Add("Для согласованности и транзакицонности рассмотри Postgres или паттерн сага + транзакционный outbox.");
        }

        if (request.IsPartitionTolerant)
        {
            advices.Add("Для распределенных систем рассмотри Mongo, Cassandra, ClickHouse");
        }

        if (request.IsTimeSeries)
        {
            advices.Add("Для временных рядов рассмотри Cassanda или ClickHouse.");
        }

        return advices;
    }
}

