
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly ICommandHandlerFactory _commandHandlerFactory;
        protected readonly IQueryHandlerFactory _queryHandlerFactory;

        public BaseApiController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
            _queryHandlerFactory = queryHandlerFactory;
        }
    }
}