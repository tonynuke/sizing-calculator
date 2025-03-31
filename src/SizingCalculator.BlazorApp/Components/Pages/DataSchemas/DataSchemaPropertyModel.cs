using SizingCalculator.BlazorApp.Components.Models;

namespace SizingCalculator.BlazorApp.Components.Pages.DataSchemas;

public record DataSchemaPropertyModel
{
    public required string Title { get; set; }
    public required DataTypeModel DataType { get; set; }
    public int? Quantity { get; set; }
}
