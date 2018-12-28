using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandHandlerFactory
    {
        Task ResolveAndExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
        void ResolveAndExecute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}