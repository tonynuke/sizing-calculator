using Pagination;

namespace SizingCalculator.Application.DataTypes;

public static class GetDataTypes
{
    public record Request : IRequest<PageContent<DataType>>
    {
        public required SkipPagination Pagination { get; init; }
    }

    public class Handler : IRequestHandler<Request, PageContent<DataType>>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public Handler(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<PageContent<DataType>> Handle(Request request, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var dbDataTypesQuery = dbContext.DataTypes
                    .AsNoTracking()
                    .OrderBy(dataType => dataType.Id);

            var count = await dbDataTypesQuery.CountAsync(cancellationToken);

            var dbDataTypes = await dbDataTypesQuery
                .Skip(request.Pagination.Skip)
                .Take(request.Pagination.Limit)
                .ToListAsync(cancellationToken);

            return new PageContent<DataType>()
            {
                Items = dbDataTypes,
                TotalItemsCount = count
            };
        }
    }
}
