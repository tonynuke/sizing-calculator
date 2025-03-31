namespace SizingCalculator.Domain;

/// <summary>
/// Свойство схемы данных.
/// </summary>
public class DataSchemaProperty
{
    public Guid Id { get; init; }

    /// <summary>
    /// Название.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Тип данных.
    /// </summary>
    public required DataType DataType { get; set; }

    // HACK: вынести в view model для UI
    public string SelectedDataTypeId { get; set; }

    /// <summary>
    /// Количество.
    /// </summary>
    /// <remarks>
    /// Для строк >= 1.
    /// </remarks>
    public int? Quantity { get; set; }

    /// <summary>
    /// Размер данных.
    /// </summary>
    public long TotalSize => DataType.Size * Quantity ?? 1;
}
