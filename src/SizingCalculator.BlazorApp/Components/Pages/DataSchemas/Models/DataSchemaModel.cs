namespace SizingCalculator.BlazorApp.Components.Pages.DataSchemas.Models;

public record DataSchemaModel
{
    public required Guid? Id { get; init; }
    public required string Title { get; set; }
    public required List<DataSchemaPropertyModel> Properties { get; init; }
    public IQueryable<DataSchemaPropertyModel> PropertiesQueryable => Properties.AsQueryable();
}
