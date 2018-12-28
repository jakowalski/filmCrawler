using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandAsyncDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
