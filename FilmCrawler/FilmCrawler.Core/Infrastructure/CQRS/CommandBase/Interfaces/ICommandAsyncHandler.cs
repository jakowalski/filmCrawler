using FilmCrawler.Core.Infrastructure.CQRS.Base.Interfaces;
using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandAsyncHandler<TCommand>: ICommandAsyncHandlerBase where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }    
}
