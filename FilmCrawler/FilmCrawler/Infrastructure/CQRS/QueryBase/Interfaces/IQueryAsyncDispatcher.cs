using System.Threading.Tasks;

namespace FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryAsyncDispatcher
    {
        Task DispatchAsync<TQuery, TResult>(TQuery command) where TQuery : IQuery;
    }
}
