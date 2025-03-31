namespace SizingCalculator.Application.DataSchemas;

public static class GetDataSchemaSize
{
    public record Request : IRequest<Response>
    {
        public required Guid Id { get; init; }
    }

    public record Response
    {
        public required Sizing? Sizing { get; init; }
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
            var dbSchema = await dbContext.DataSchemas
                .AsNoTracking()
                .Where(schema => schema.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            var sizing = dbSchema?.GetSizing();
            return new Response { Sizing = sizing };
        }
    }
}
