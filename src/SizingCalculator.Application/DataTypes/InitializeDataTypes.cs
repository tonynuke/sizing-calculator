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
            var dataTypeByIds = Domain.DataTypes.Types.ToDictionary(dataType => dataType.Id);
            var dataTypeIds = dataTypeByIds.Keys;

            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var dbTypeIds = await dbContext.DataTypes
                .Where(dataType => dataTypeIds.Contains(dataType.Id))
                .Select(dataType => dataType.Id)
                .ToListAsync(cancellationToken);

            foreach (var dbTypeId in dbTypeIds)
            {
                dataTypeByIds.Remove(dbTypeId);
            }

            await dbContext.DataTypes.AddRangeAsync(dataTypeByIds.Values, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
