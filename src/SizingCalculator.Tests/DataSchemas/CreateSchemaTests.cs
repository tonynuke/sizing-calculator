using SizingCalculator.Application.DataSchemas;
using SizingCalculator.Tests.Common;

namespace SizingCalculator.Tests.DataSchemas;

[Collection(DatabaseCollection.Name)]
public class CreateSchemaTests
{
    private readonly IMediator _mediator;

    public CreateSchemaTests()
    {
        var provider = TestFixture.ConfigureTest().BuildServiceProvider();
    }

    [Fact]
    public void Create_schema()
    {
        var createDataSchemaRequest = new CreateDataSchema.Request { Title = "Title", Properties = [] };
    }
}
