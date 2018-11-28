using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryAsyncHandler<TQuery, TResult>: IQueryAsyncHandlerBase where TQuery : IQuery
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
