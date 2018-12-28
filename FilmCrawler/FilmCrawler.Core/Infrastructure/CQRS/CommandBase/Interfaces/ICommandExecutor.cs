using System.Collections.Generic;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandExecutor
    {
        void Execute(IEnumerable<ICommand> commands);
    }
}
