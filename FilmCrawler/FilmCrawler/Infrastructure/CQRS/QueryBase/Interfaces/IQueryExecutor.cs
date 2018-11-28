using System.Collections.Generic;

namespace FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryExecutor
    {
        void Execute(IEnumerable<IQuery> queries);
    }
}
