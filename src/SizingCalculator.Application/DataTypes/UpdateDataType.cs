namespace SizingCalculator.Application.DataTypes;

public static class UpdateDataType
{
    public record Request : IRequest
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required long Size { get; init; }
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
                .Where(dataType => dataType.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            dbDataType.Size = request.Size;
            dbDataType.Title = request.Title;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
