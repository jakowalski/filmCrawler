using System.Threading.Tasks;
using Autofac;
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.CommandBase
{
    public class AutofacCommandAsyncDispatcher : ICommandAsyncDispatcher
    {
        private readonly IComponentContext _context;

        public AutofacCommandAsyncDispatcher(IComponentContext context)
        {
            this._context = context;
        }
        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _context.Resolve<ICommandAsyncHandler<TCommand>>();
            await handler.ExecuteAsync(command);
        }
    }
}
