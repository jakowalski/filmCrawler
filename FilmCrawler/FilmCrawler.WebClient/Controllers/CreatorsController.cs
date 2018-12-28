using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.WebClient.Features.GetCreatorsCountQuery;
using FilmCrawler.WebClient.Features.GetCreatorsQuery;
using FilmCrawler.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Controllers
{
    public class CreatorsController : BaseController
    {
        public CreatorsController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory) : base(commandHandlerFactory, queryHandlerFactory)
        {
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            var creatorCount = await _queryHandlerFactory.ResolveAndExecuteAsync<GetCreatorsCountQuery, long>(new GetCreatorsCountQuery());
            var creators = await _queryHandlerFactory.ResolveAndExecuteAsync<GetCreatorsQuery, List<CreatorDto>>(new GetCreatorsQuery(pageIndex));
            return View(new CreatorViewModel { Creators = creators, Count = creatorCount });
        }
    }
}