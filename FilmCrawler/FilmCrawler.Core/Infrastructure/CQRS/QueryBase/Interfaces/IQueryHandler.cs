using FilmCrawler.Core.Infrastructure.CQRS.Base.Interfaces;

namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>: IQueryHandlerBase where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}
