using Microsoft.FluentUI.AspNetCore.Components;

namespace SizingCalculator.BlazorApp;

public static class Extensions
{
    public static GridItemsProviderResult<T> ToProviderResult<T>(this Pagination.PageContent<T> pageContent)
    {
        return GridItemsProviderResult.From<T>(
            pageContent.Items.ToList(),
            pageContent.TotalItemsCount.Value);
    }

    public static GridItemsProviderResult<T1> ToProviderResult<T, T1>(
        this Pagination.PageContent<T> pageContent,
        Func<T, T1> map)
    {
        return GridItemsProviderResult.From<T1>(
            pageContent.Items.Select(map).ToList(),
            pageContent.TotalItemsCount.Value);
    }

    public static Pagination.SkipPagination ToSkipPagination<T>(this GridItemsProviderRequest<T> request)
    {
        return new Pagination.SkipPagination
        {
            Skip = request.StartIndex,
            Limit = request.Count!.Value
        };
    }
}
