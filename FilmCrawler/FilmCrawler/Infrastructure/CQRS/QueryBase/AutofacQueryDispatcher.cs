using Autofac;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.QueryBase
{
    public class AutofacQueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public AutofacQueryDispatcher(IComponentContext context)
        {
            this._context = context;
        }

        public void Dispatch<TQuery, TResult>(TQuery command) where TQuery : IQuery
        {
            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();
            handler.Execute(command);
        }
    }
}
