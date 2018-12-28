using System.Collections.Generic;

namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryExecutor
    {
        void Execute(IEnumerable<IQuery> queries);
    }
}
