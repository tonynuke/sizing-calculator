using SizingCalculator.Application.DataSchemas;
using SizingCalculator.Domain;

namespace SizingCalculator.Tests.Common;

internal static class Extensions
{
    public static async Task<DataSchema?> GetSchemaById(this IMediator mediator, Guid schemaId)
    {
        var request = new GetDataSchema.Request { Id = schemaId };
        var response = await mediator.Send(request);
        return response.DataSchema;
    }
}
