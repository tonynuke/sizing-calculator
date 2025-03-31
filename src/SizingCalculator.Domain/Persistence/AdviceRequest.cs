namespace SizingCalculator.Domain.Persistence;

public record AdviceRequest
{
    /// <summary>
    /// Сайзинг.
    /// </summary>
    public required Sizing Sizing { get; init; }

    /// <summary>
    /// Требуется согласованность. Например, транзационность.
    /// </summary>
    public bool IsConsistent { get; init; }

    /// <summary>
    /// Требуется распределенность.
    /// </summary>
    public bool IsPartitionTolerant { get; init; }

    /// <summary>
    /// Требуется высокая доступность.
    /// </summary>
    public bool IsHighAvaiable { get; init; }

    /// <summary>
    /// Данные являются временным рядом.
    /// </summary>
    public bool IsTimeSeries { get; init; }

    /// <summary>
    /// Записей в секунду.
    /// </summary>
    public long WritesPerSecond { get; init; }

    /// <summary>
    /// Чтений в секнуду.
    /// </summary>
    public long ReadsPerSecond { get; init; }
}
