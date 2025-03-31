namespace SizingCalculator.BlazorApp.Components.Models;

public record DataTypeModel
{
    public Guid Id { get; init; }
    public required string Title { get; set; }
    public required int Size { get; set; }
}
