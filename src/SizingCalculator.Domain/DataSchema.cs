namespace SizingCalculator.Domain;

/// <summary>
/// Схема данных.
/// </summary>
public class DataSchema
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Название.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Свойства.
    /// </summary>
    public required List<DataSchemaProperty> Properties { get; init; }

    /// <summary>
    /// Настройки сайзинга.
    /// </summary>
    public SizingOptions SizingOptions { get; set; } = new SizingOptions { RowsCount = 0, Multiplier = MultiplierType.None };

    /// <summary>
    /// Рассчитывает размер для хранения данных.
    /// </summary>
    /// <param name="rowsCount"></param>
    /// <returns></returns>
    public Sizing GetSizing()
    {
        var rowSize = Properties.Sum(row => row.TotalSize);
        var totalSize = rowSize * SizingOptions.TotalRowsCount();

        return new Sizing
        {
            RowSize = rowSize,
            TotalSize = totalSize
        };
    }
}