﻿namespace SizingCalculator.BlazorApp.Components.Pages.DataSchemas;

public record DataSchemaModel
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required List<DataSchemaPropertyModel> Properties { get; init; }
}
