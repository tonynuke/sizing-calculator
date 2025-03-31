namespace SizingCalculator.Domain;

/// <summary>
/// Тип данных.
/// </summary>
public class DataType
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
    /// Объем в байтах.
    /// </summary>
    public required long Size { get; set; }
}
