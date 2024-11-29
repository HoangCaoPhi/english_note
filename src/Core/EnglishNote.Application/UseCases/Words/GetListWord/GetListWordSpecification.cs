using EnglishNote.Application.Abtractions.Queries;
using EnglishNote.Domain.AggregatesModel.Words;
using System.Linq.Expressions;

namespace EnglishNote.Application.UseCases.Words.GetListWord;
internal class GetListWordSpecification(IQueryable<Word> query, GetListWordQuery filter) : PagingSpecification<Word, GetListWordQuery, GetListWordViewModel>(query, filter)
{
    public override IQueryable<Word> ApplyFilters(IQueryable<Word> query, GetListWordQuery filter)
    {
        if(!string.IsNullOrWhiteSpace(filter.WordText))
            query.Where(x => x.WordText.Contains(filter.WordText));

        if(filter.TagId is not null)
            query.Where(x => x.TagId == filter.TagId);

        return query;
    }

    public override IQueryable<Word> ApplyIncludes(IQueryable<Word> query)
    {
        return query;
    }

    public override Expression<Func<Word, object>> SortByProperty(GetListWordQuery filter)
    {
        return t => t.Id;
    }
}
