using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base;

namespace FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandAsyncHandler<TCommand>: ICommandAsyncHandlerBase where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }    
}
