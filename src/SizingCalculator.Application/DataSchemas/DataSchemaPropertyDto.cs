namespace SizingCalculator.Application.DataSchemas;

public record DataSchemaPropertyDto
{
    public required string Title { get; set; }
    public required Guid DataTypeId { get; set; }
    public int? Quantity { get; set; }
}
