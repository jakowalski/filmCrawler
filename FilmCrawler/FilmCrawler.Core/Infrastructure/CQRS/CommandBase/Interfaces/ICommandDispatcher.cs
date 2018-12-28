
namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
