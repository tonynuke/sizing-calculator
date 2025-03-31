using SizingCalculator.Application.DataSchemas;
using SizingCalculator.Application.DataTypes;
using SizingCalculator.Domain;
using SizingCalculator.Tests.Common;

namespace SizingCalculator.Tests.DataSchemas;

[Collection(DatabaseCollection.Name)]
public class CreateSchemaTests
{
    private readonly IMediator _mediator;

    public CreateSchemaTests()
    {
        var provider = TestFixture.ConfigureTest().BuildServiceProvider();
        _mediator = provider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Create_schema()
    {
        var initializeDataTypesRequest = new InitializeDataTypes.Request();
        await _mediator.Send(initializeDataTypesRequest);

        var createDataSchemaRequest = new CreateDataSchema.Request
        {
            Title = "User",
            Properties = [
                new() { DataTypeId = DataTypes.Guid.Id, Title = "id"},
                new() { DataTypeId = DataTypes.Text.Id, Title = "name", Quantity = 20},
                ]
        };
        await _mediator.Send(createDataSchemaRequest);
    }
}
