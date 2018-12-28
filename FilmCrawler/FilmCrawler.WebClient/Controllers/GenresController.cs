

using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.WebClient.Features.GetGenresQuery;
using FilmCrawler.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Controllers
{
    public class GenresController : BaseController
    {
        public GenresController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory) : base(commandHandlerFactory, queryHandlerFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var genres=await _queryHandlerFactory.ResolveAndExecuteAsync< GetGenresQuery,List<GenreDto>> (new GetGenresQuery());
            return View(new GenreViewModel { Genres = genres });
        }
    }
}