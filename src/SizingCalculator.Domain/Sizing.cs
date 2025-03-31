namespace SizingCalculator.Domain;

/// <summary>
/// Размер.
/// </summary>
public record Sizing
{
    /// <summary>
    /// Размер в байтах.
    /// </summary>
    public required long Size { get; init; }

    /// <summary>
    /// Преобразует размер в человекочитаемую строку.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public string ConvertBytesToReadableSize()
    {
        if (Size < 0)
        {
            throw new ArgumentException("Размер не может быть отрицательным", nameof(Size));
        }

        const int scale = 1024;
        var units = new[] { "B", "KB", "MB", "GB", "TB" };
        var maxUnitsIndex = units.Length - 1;

        double adjustedSize = Size;
        var unitIndex = 0;

        while (adjustedSize >= scale && unitIndex < maxUnitsIndex)
        {
            adjustedSize /= scale;
            unitIndex++;
        }

        return $"{adjustedSize:0.##} {units[unitIndex]}";
    }
}
