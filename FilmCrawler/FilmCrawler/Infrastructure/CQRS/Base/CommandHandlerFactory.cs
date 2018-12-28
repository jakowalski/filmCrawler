using System;
using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;
using FilmCrawler.Infrastructure.CQRS.CommandBase;
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.Base
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Func<Type, ICommandHandlerBase> _handlersFactory;
        private readonly Func<Type, ICommandAsyncHandlerBase> _asyncHandlersFactory;


        public CommandHandlerFactory(Func<Type, ICommandHandlerBase> handlersFactory, Func<Type, ICommandAsyncHandlerBase> asyncHandlersFactory)
        {
            _handlersFactory = handlersFactory;
            _asyncHandlersFactory = asyncHandlersFactory;
        }

        public async Task ResolveAndExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var handler = (ICommandAsyncHandler<TCommand>)_asyncHandlersFactory(typeof(TCommand));
                await handler.ExecuteAsync(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void ResolveAndExecute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_handlersFactory(typeof(TCommand));
            handler.Execute(command);
        }
    }
}
