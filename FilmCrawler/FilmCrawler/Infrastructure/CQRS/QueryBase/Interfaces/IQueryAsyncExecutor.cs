using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryAsyncExecutor
    {
        Task ExecuteAsync(IEnumerable<IQuery> queries);
    }
}
