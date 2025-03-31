﻿namespace SizingCalculator.BlazorApp.Components.Pages.DataTypes;

public record DataTypeModel
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required int Size { get; set; }
}
