namespace SizingCalculator.Domain.Persistence;

public sealed class Database
{
    /// <summary>
    /// Название.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Максимальный размер таблицы/коллекции.
    /// </summary>
    public required double? MaxTableSize { get; set; }

    /// <summary>
    /// Максимальный размер строки.
    /// </summary>
    public required double? MaxRowSize { get; set; }

    /// <summary>
    /// Макисмальный размер колонки.
    /// </summary>
    public required double? MaxColumnSize { get; set; }

    /// <summary>
    /// Поддерживает шардирование.
    /// </summary>
    public required bool IsShardingAvailable { get; set; }

    /// <summary>
    /// Поддерживает транзакции.
    /// </summary>
    public required bool IsTranasctional { get; set; }
}
