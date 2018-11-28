using System;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.Base
{
    public abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {        
        public virtual TResult Execute(TQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            //add logging here if it will be needed - G.Niemiec
            
            return RunQuery(query);
        }

        protected abstract TResult RunQuery(TQuery query);
    }
}