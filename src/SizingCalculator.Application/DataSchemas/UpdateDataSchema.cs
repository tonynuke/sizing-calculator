namespace SizingCalculator.Application.DataSchemas;

public static class UpdateDataSchema
{
    public record Request : IRequest
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required IReadOnlyCollection<DataSchemaPropertyDto> Properties { get; init; }
    }

    public class Handler : IRequestHandler<Request>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public Handler(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Handle(Request request, CancellationToken cancellationToken)
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

            var dbSchema = await dbContext.DataSchemas
              .AsNoTracking()
              .Where(schema => schema.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
