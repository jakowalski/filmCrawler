using System.Threading.Tasks;

namespace FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandHandlerFactory
    {
        Task ResolveAndExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
        void ResolveAndExecute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}