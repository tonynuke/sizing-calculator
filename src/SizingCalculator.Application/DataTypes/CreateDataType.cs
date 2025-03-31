namespace SizingCalculator.Application.DataTypes;

public static class CreateDataType
{
    public record Request : IRequest<Response>
    {
        public required string Title { get; init; }
        public required long Size { get; init; }
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
            var dataType = new DataType { Size = request.Size, Title = request.Title };

            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            await dbContext.DataTypes.AddAsync(dataType, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response { Id = dataType.Id };
        }
    }
}
