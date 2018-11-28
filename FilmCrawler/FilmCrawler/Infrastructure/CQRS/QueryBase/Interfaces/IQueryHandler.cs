using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>: IQueryHandlerBase where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}
