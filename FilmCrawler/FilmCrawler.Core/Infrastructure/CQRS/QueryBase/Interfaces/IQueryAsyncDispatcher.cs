using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryAsyncDispatcher
    {
        Task DispatchAsync<TQuery, TResult>(TQuery command) where TQuery : IQuery;
    }
}
