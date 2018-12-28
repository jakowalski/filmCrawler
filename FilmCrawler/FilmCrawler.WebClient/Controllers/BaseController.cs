using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FilmCrawler.WebClient.Controllers
{
    public class BaseController:Controller
    {
        protected readonly ICommandHandlerFactory _commandHandlerFactory;
        protected readonly IQueryHandlerFactory _queryHandlerFactory;

        public BaseController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
            _queryHandlerFactory = queryHandlerFactory;
        }
    }
}
