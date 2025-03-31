namespace SizingCalculator.Application.DataSchemas;

public static class CreateDataSchema
{
    public record Request : IRequest<Response>
    {
        public Guid? Id { get; init; }
        public required string Title { get; init; }
        public required IReadOnlyCollection<DataSchemaPropertyDto> Properties { get; init; }
        public SizingOptions SizingOptions { get; init; } = new SizingOptions { RowsCount = 1 };
    }

    public record Response
    {
        public required Guid Id { get; init; }
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public Handler(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var expectedDataTypeIds = request.Properties.Select(property => property.DataTypeId).ToList();

            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var dbDataTypes = await dbContext.DataTypes
                .Where(dataType => expectedDataTypeIds.Contains(dataType.Id))
                .ToDictionaryAsync(dataType => dataType.Id, cancellationToken);

            var properties = request.Properties
                .Select(property => new DataSchemaProperty
                {
                    DataType = dbDataTypes[property.DataTypeId],
                    Title = property.Title,
                    Quantity = property.Quantity
                })
                .ToList();

            var dataSchema = new DataSchema { Id = request.Id ?? Guid.NewGuid(), Title = request.Title, Properties = properties, SizingOptions = request.SizingOptions };

            await dbContext.DataSchemas.AddAsync(dataSchema, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response { Id = dataSchema.Id };
        }
    }
}
