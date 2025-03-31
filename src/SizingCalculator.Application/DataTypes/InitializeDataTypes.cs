namespace SizingCalculator.Application.DataTypes;

public static class InitializeDataTypes
{
    public record Request : IRequest;

    public class Handler : IRequestHandler<Request>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        private static readonly IReadOnlyCollection<DataType> Types = [
            new DataType
            {
                Id = Guid.Parse("08f657c5-5fd3-4fd8-86d7-c728b51068fd"),
                Title = "integer",
                Size = 4
            },
            new DataType
            {
                Id = Guid.Parse("63050397-67f1-4916-a773-cdde27a79a93"),
                Title = "bigint",
                Size = 8
            },
            new DataType
            {
                Id = Guid.Parse("8587199a-9ae0-40b4-86f8-89ff8b6b4e7f"),
                Title = "guid",
                Size = 16
            },
            new DataType
            {
                Id = Guid.Parse("e2a769cb-4193-4b4e-b274-97e0458de3b9"),
                Title = "text",
                Size = 4
            },
            new DataType
            {
                Id = Guid.Parse("88ba1af1-8d2d-4cba-a616-e446a9fe078b"),
                Title = "timestamp",
                Size = 4
            },
        ];

        public Handler(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Handle(Request request, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            await dbContext.DataTypes.AddRangeAsync(Types, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
