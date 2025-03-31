namespace SizingCalculator.Application.DataTypes;

public static class InitializeDataTypes
{
    public record Request : IRequest;

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
            await dbContext.DataTypes.AddRangeAsync(Domain.DataTypes.Types, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
