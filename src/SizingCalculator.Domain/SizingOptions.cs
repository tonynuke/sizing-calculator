namespace SizingCalculator.Domain;

public record SizingOptions
{
    public static readonly IReadOnlyDictionary<MultiplierType, long> Multiplires = new Dictionary<MultiplierType, long>()
    {
        { MultiplierType.None, 1 },
        { MultiplierType.Hundred, 100 },
        { MultiplierType.Thousand, 1_000 },
        { MultiplierType.Million, 1_000_000 },
        { MultiplierType.Billion, 1_000_000_000 },
        { MultiplierType.Trillion, 1_000_000_000_000 },
    };

    public required long RowsCount { get; set; }

    public MultiplierType Multiplier { get; set; } = MultiplierType.None;

    public long TotalRowsCount() => Multiply(RowsCount, Multiplier);

    public static long Multiply(long value, MultiplierType multiplerType)
    {
        return value * Multiplires[multiplerType];
    }
}
