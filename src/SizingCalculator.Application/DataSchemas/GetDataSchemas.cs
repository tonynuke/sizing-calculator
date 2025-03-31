using Pagination;

namespace SizingCalculator.Application.DataSchemas;

public static class GetDataSchemas
{
    public record Request : IRequest<PageContent<DataSchema>>
    {
        public required SkipPagination Pagination { get; init; }
    }

    public class Handler : IRequestHandler<Request, PageContent<DataSchema>>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public Handler(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<PageContent<DataSchema>> Handle(Request request, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var dbDataSchemasQuery = dbContext.DataSchemas
                .AsNoTracking()
                .OrderBy(schema => schema.Id);

            var count = await dbDataSchemasQuery.CountAsync(cancellationToken);

            var dbDataSchemas = await dbDataSchemasQuery
                .Skip(request.Pagination.Skip)
                .Take(request.Pagination.Limit)
                .ToListAsync(cancellationToken);

            return new PageContent<DataSchema>()
            {
                Items = dbDataSchemas,
                TotalItemsCount = count
            };
        }
    }
}
