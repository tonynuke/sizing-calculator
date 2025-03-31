namespace SizingCalculator.Application.DataSchemas;

public static class UpdateDataSchemaProperty
{
    public record Request : IRequest
    {
        public required Guid Id { get; init; }
        public required DataSchemaPropertyDto Property { get; init; }
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
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var dbDataType = await dbContext.DataTypes
                .Where(dataType => dataType.Id == request.Property.DataTypeId)
                .SingleOrDefaultAsync(cancellationToken);

            var property = new DataSchemaProperty
            {
                DataType = dbDataType,
                Title = request.Property.Title,
                Quantity = request.Property.Quantity
            };

            var dbSchema = await dbContext.DataSchemas
              .AsNoTracking()
              .Where(schema => schema.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
