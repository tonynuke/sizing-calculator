namespace SizingCalculator.Application.DataSchemas;

public static class GetDataSchema
{
    public record Request : IRequest<Response>
    {
        public required Guid Id { get; init; }
    }

    public record Response
    {
        public required DataSchema? DataSchema { get; init; }
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
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var dbDataSchema = await dbContext.DataSchemas
                .AsNoTracking()
                .Where(schema => schema.Id == request.Id)
                .Include(schema => schema.Properties)
                .ThenInclude(schema => schema.DataType)
                .SingleOrDefaultAsync(cancellationToken);

            return new Response { DataSchema = dbDataSchema };
        }
    }
}
