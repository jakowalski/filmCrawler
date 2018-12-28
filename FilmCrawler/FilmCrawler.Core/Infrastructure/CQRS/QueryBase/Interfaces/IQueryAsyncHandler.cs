using FilmCrawler.Core.Infrastructure.CQRS.Base.Interfaces;
using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryAsyncHandler<TQuery, TResult>: IQueryAsyncHandlerBase where TQuery : IQuery
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
