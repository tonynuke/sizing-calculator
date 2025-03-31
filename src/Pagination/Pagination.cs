namespace Pagination;

public record SkipPagination
{
    public required int Skip { get; init; }
    public required int Limit { get; init; }
}

public record IndexPagination
{
    public required int LastIndex { get; init; }
    public required int Limit { get; init; }
}

public record PageContent<T>
{
    public required IReadOnlyCollection<T> Items { get; set; }
    public int? TotalItemsCount { get; set; }
    public int? LastItemIndex { get; set; }
}
