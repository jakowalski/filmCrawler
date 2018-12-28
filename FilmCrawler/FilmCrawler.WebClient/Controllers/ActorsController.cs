using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.WebClient.Features.GetActorsCountQuery;
using FilmCrawler.WebClient.Features.GetActorsQuery;
using FilmCrawler.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Controllers
{
    public class ActorsController : BaseController
    {
        public ActorsController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory) : base(commandHandlerFactory, queryHandlerFactory)
        {
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            var actorsCount = await _queryHandlerFactory.ResolveAndExecuteAsync<GetActorsCountQuery, long>(new GetActorsCountQuery());
            var actors = await _queryHandlerFactory.ResolveAndExecuteAsync<GetActorsQuery, List<ActorDto>>(new GetActorsQuery(pageIndex));
            return View(new ActorViewModel { Actors = actors, Count = actorsCount });
        }
    }
}