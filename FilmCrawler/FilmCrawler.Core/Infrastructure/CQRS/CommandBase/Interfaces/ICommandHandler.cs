using FilmCrawler.Core.Infrastructure.CQRS.Base.Interfaces;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{    
    public interface ICommandHandler<TCommand>:ICommandHandlerBase where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
