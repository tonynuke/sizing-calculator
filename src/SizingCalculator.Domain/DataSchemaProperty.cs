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

    /// <summary>
    /// Количество.
    /// </summary>
    /// <remarks>
    /// Для строк >= 1.
    /// </remarks>
    public int? Quantity { get; set; }
}
