using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnglishNote.Application.Abtractions.Queries;

interface IPagingSpecification { }

public abstract class PagingSpecification<TReadModel, TFilter, TViewModel> : IPagingSpecification
    where TFilter : PagingModel
{
    private IQueryable<TReadModel> Query;
    private readonly TFilter Filter;

    public PagingSpecification(IQueryable<TReadModel> query, TFilter filter)
    {
        Query = query ?? throw new ArgumentNullException(nameof(query));
        Filter = filter ?? throw new ArgumentNullException(nameof(filter));

        Query = ApplyIncludes(Query);
        Query = ApplyFilters(Query, Filter);
        Query = ApplySorting(Query);
    }

    public abstract IQueryable<TReadModel> ApplyIncludes(IQueryable<TReadModel> query);

    public abstract IQueryable<TReadModel> ApplyFilters(IQueryable<TReadModel> query, TFilter filter);

    public virtual IQueryable<TReadModel> ApplySorting(IQueryable<TReadModel> query)
    {
        if (!string.IsNullOrEmpty(Filter.SortField))
        {
            var sortExpression = SortByProperty(Filter);
            query = Filter.SortDirection == OrderByDirectionEnum.ASC
                ? query.OrderBy(sortExpression)
                : query.OrderByDescending(sortExpression);
        }

        return query;
    }

    public abstract Expression<Func<TReadModel, object>> SortByProperty(TFilter filter);

    public async Task<PaginatedList<TViewModel>> ApplyPaging()
    {
        var pageIndex = Filter.PageIndex ?? 1;
        var pageSize = Filter.PageSize ?? 10;

        var count = await Query.CountAsync();    
        var items = await Query
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ProjectToType<TViewModel>()
                            .ToListAsync();

        return new PaginatedList<TViewModel>(items, count, pageIndex, pageSize);
    }

    public IQueryable<TReadModel> GetQuery() => Query;
}