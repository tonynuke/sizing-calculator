namespace SizingCalculator.Domain;

/// <summary>
/// Размер.
/// </summary>
public record Sizing
{
    /// <summary>
    /// Размер строки в байтах.
    /// </summary>
    public required long RowSize { get; init; }

    /// <summary>
    /// Размер схемы в байтах.
    /// </summary>
    public required long TotalSize { get; init; }

    /// <summary>
    /// Преобразует размер в человекочитаемую строку.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ConvertBytesToReadableSize(long totalSize)
    {
        if (totalSize < 0)
        {
            throw new ArgumentException("Размер не может быть отрицательным", nameof(totalSize));
        }

        const int scale = 1024;
        var units = new[] { "B", "KB", "MB", "GB", "TB", "PB" };
        var maxUnitsIndex = units.Length - 1;

        double adjustedSize = totalSize;
        var unitIndex = 0;

        while (adjustedSize >= scale && unitIndex < maxUnitsIndex)
        {
            adjustedSize /= scale;
            unitIndex++;
        }

        return $"{adjustedSize:0.##} {units[unitIndex]}";
    }
}
