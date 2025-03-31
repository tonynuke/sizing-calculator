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
    /// Рассчитывает размер для хранения данных.
    /// </summary>
    /// <param name="rowsCount"></param>
    /// <returns></returns>
    public Sizing GetSizing(long rowsCount)
    {
        var rowSize = Properties.Sum(row => row.TotalSize);
        var totalSize = rowSize * rowsCount;

        return new Sizing
        {
            RowSize = rowSize,
            TotalSize = totalSize
        };
    }
}
