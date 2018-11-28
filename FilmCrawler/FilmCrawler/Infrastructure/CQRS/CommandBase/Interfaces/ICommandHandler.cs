using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;

namespace FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces
{    
    public interface ICommandHandler<TCommand>:ICommandHandlerBase where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
