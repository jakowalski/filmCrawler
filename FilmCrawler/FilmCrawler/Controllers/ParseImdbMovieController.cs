
using System;
using System.Threading.Tasks;
using FilmCrawler.Features.ParseImdbMovieCommand;
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;
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
        public async Task Post(string fileName)
        {
            await _commandHandlerFactory.ResolveAndExecuteAsync(new ParseImdbMovieCommand(fileName));
        }

    }
}