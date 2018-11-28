using System;
using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.Base
{
    public abstract class BaseQueryAsyncHandler<TQuery, TResult> : IQueryAsyncHandler<TQuery, TResult> where TQuery : IQuery
    {
        public virtual async Task<TResult> ExecuteAsync(TQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            //add logging here if it will be needed - G.Niemiec

            return await RunQueryAsync(query);
        }

        protected abstract Task<TResult> RunQueryAsync(TQuery query);
    }
}