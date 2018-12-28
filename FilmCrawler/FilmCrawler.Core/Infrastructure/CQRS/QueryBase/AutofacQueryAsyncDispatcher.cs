using System.Threading.Tasks;
using Autofac;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase
{
    public class AutofacQueryAsyncDispatcher : IQueryAsyncDispatcher
    {
        private readonly IComponentContext _context;

        public AutofacQueryAsyncDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task DispatchAsync<TQuery, TResult>(TQuery command) where TQuery : IQuery
        {
            var handler = _context.Resolve<IQueryAsyncHandler<TQuery, TResult>>();
            await handler.ExecuteAsync(command);
        }
    }
}
