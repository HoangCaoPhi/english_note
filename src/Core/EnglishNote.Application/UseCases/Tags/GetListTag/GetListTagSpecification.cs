using EnglishNote.Application.Abtractions.Queries;
using EnglishNote.Domain.AggregatesModel.Tags;
using System.Linq.Expressions;

namespace EnglishNote.Application.UseCases.Tags.GetListTag;

public class GetListTagSpecification(IQueryable<Tag> query, GetListTagQuery filter) :
       PagingSpecification<Tag, GetListTagQuery, GetListTagViewModel>(query, filter)
{
    public override IQueryable<Tag> ApplyIncludes(IQueryable<Tag> query)
    {
        return query;
    }

    public override IQueryable<Tag> ApplyFilters(IQueryable<Tag> query, GetListTagQuery filter)
    {
        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(t => t.Name.Contains(filter.Name));

        if (!string.IsNullOrEmpty(filter.Description))
            query = query.Where(t => t.Description.Contains(filter.Description));

        return query;
    }

    public override Expression<Func<Tag, object>> SortByProperty(GetListTagQuery filter)
    {
        if (filter.SortField == "Name")
        {
            return t => t.Name;
        }

        return t => t.Id;
    }
}