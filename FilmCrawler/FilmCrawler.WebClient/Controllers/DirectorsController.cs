using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.WebClient.Features.GetDirectorsCountQuery;
using FilmCrawler.WebClient.Features.GetDirectorsQuery;
using FilmCrawler.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Controllers
{
    public class DirectorsController : BaseController
    {
        public DirectorsController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory) : base(commandHandlerFactory, queryHandlerFactory)
        {
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            var directorsCount = await _queryHandlerFactory.ResolveAndExecuteAsync<GetDirectorsCountQuery, long>(new GetDirectorsCountQuery());
            var directors = await _queryHandlerFactory.ResolveAndExecuteAsync<GetDirectorsQuery, List<DirectorDto>>(new GetDirectorsQuery(pageIndex));
            return View(new DirectorViewModel {Directors=directors, Count= directorsCount });
        }
    }
}