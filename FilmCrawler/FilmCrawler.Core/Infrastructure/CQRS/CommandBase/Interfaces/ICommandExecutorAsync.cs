using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces
{
    public interface ICommandExecutorAsync
    {
        Task ExectueAsync(IEnumerable<ICommand> commands);
    }
}
