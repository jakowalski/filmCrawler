using System;
using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.Base
{
    public class QueryHandlerFactory:IQueryHandlerFactory
    {
        private readonly Func<Type,Type, IQueryHandlerBase> _handlersFactory;
        private readonly Func<Type, Type, IQueryAsyncHandlerBase> _asyncHandlersFactory;


        public QueryHandlerFactory(Func<Type,Type, IQueryHandlerBase> handlersFactory, Func<Type, Type, IQueryAsyncHandlerBase> asyncHandlersFactory)
        {
            _asyncHandlersFactory = asyncHandlersFactory;
            _handlersFactory = handlersFactory;
        }
        public async Task<TResult> ResolveAndExecuteAsync<TQuery,TResult>(TQuery command) where TQuery : IQuery
        {
            var handler = (IQueryAsyncHandler<TQuery,TResult>)_asyncHandlersFactory(typeof(TQuery),typeof(TResult));
            return await handler.ExecuteAsync(command);
        }

        public TResult ResolveAndExecute<TQuery,TResult>(TQuery command) where TQuery : IQuery
        {
            var handler = (IQueryHandler<TQuery, TResult>)_handlersFactory(typeof(TQuery),typeof(TResult));
            return handler.Execute(command);
        }
    }
}
