using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using FilmCrawler.Features.ParseImdbMovieCommand;
using Microsoft.AspNetCore.Mvc;

namespace FilmCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParseImdbMovieController : BaseApiController
    {
        public ParseImdbMovieController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory) : base(commandHandlerFactory, queryHandlerFactory)
        {
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(string fileName)
        {
            await _commandHandlerFactory.ResolveAndExecuteAsync(new ParseImdbMovieCommand(fileName));
            return Ok();
        }

    }
}