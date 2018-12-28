using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryHandlerFactory
    {
        Task<TResult> ResolveAndExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;

        TResult ResolveAndExecute<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}