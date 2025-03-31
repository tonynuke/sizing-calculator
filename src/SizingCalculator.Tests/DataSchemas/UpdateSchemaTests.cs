using SizingCalculator.Application.DataSchemas;
using SizingCalculator.Application.DataTypes;
using SizingCalculator.Domain;

namespace SizingCalculator.Tests.DataSchemas;

[Collection(DatabaseCollection.Name)]
public class UpdateSchemaTests
{
    private readonly IMediator _mediator;

    public UpdateSchemaTests()
    {
        var provider = TestFixture.ConfigureTest().BuildServiceProvider();
        _mediator = provider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Update_schema()
    {
        var initializeDataTypesRequest = new InitializeDataTypes.Request();
        await _mediator.Send(initializeDataTypesRequest);

        var createDataSchemaRequest = new CreateDataSchema.Request
        {
            Title = "User",
            Properties = [
                new() { DataTypeId = DataTypes.Guid.Id, Title = "id"},
                new() { DataTypeId = DataTypes.Text.Id, Title = "name", Quantity = 20},
                ],
            SizingOptions = new SizingOptions { RowsCount = 1 }
        };
        var createDataSchemaResponse = await _mediator.Send(createDataSchemaRequest);

        var expectedSchema = new DataSchema
        {
            Id = createDataSchemaResponse.Id,
            Title = createDataSchemaRequest.Title,
            Properties =
            [
                new DataSchemaProperty { DataType = DataTypes.Guid, Title = "id" },
                new DataSchemaProperty { DataType = DataTypes.Text, Title = "name", Quantity = 20 },
            ],
            SizingOptions = new SizingOptions { RowsCount = 1 }
        };
        var actualSchema = await _mediator.GetSchemaById(createDataSchemaResponse.Id);
        actualSchema.Should().BeEquivalentTo(
            expectedSchema,
            options => options.For(dataSchema => dataSchema.Properties).Exclude(property => property.Id));

        var updateDataSchemaRequest = new UpdateDataSchema.Request
        {
            Id = createDataSchemaResponse.Id,
            Title = "User" + Guid.NewGuid(),
            Properties =
            [
                new() { DataTypeId = DataTypes.Guid.Id, Title = "id"},
                new() { DataTypeId = DataTypes.Text.Id, Title = "name", Quantity = 20},
                new() { DataTypeId = DataTypes.Timestamp.Id, Title = "date"},
            ],
            SizingOptions = new SizingOptions { RowsCount = 1 }
        };
        await _mediator.Send(updateDataSchemaRequest);

        var expectedSchemaAfterUpdate = new DataSchema
        {
            Id = updateDataSchemaRequest.Id,
            Title = updateDataSchemaRequest.Title,
            Properties =
            [
                new() { DataType = DataTypes.Guid, Title = "id" },
                new() { DataType = DataTypes.Text, Title = "name", Quantity = 20 },
                new() { DataType = DataTypes.Timestamp, Title = "date"},
            ],
            SizingOptions = new SizingOptions { RowsCount = 1 }
        };
        var actualSchemaAfterUpdate = await _mediator.GetSchemaById(createDataSchemaResponse.Id);
        actualSchemaAfterUpdate.Should().BeEquivalentTo(
            expectedSchemaAfterUpdate,
            options => options.For(dataSchema => dataSchema.Properties).Exclude(property => property.Id));
    }
}
