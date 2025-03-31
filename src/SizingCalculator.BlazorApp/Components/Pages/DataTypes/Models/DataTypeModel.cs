namespace SizingCalculator.BlazorApp.Components.Pages.DataTypes.Models;

public record DataTypeModel
{
    public Guid? Id { get; init; }
    public required string Title { get; set; }
    public required long Size { get; set; }
    public bool IsNew => Id is null;
}
