namespace SizingCalculator.Application.DataSchemas;

public static class DeleteDataSchema
{
    public record Request : IRequest
    {
        public required Guid Id { get; init; }
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
            await dbContext.DataSchemas
                .Where(dataSchema => dataSchema.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
