using System.Collections.Generic;

namespace FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandExecutor
    {
        void Execute(IEnumerable<ICommand> commands);
    }
}
