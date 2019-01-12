using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;
using FilmCrawler.WebClient.Features.GetMovieDetailsQuery;
using FilmCrawler.WebClient.Features.GetMoviesCountQuery;
using FilmCrawler.WebClient.Features.GetMoviesQuery;
using FilmCrawler.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Controllers
{
    public class MoviesController : BaseController
    {
        public MoviesController(ICommandHandlerFactory commandHandlerFactory, IQueryHandlerFactory queryHandlerFactory) : base(commandHandlerFactory, queryHandlerFactory)
        {
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            var moviesCount = await _queryHandlerFactory.ResolveAndExecuteAsync<GetMoviesCountQuery, long>(new GetMoviesCountQuery());
            var moviesResult = await _queryHandlerFactory.ResolveAndExecuteAsync<GetMoviesQuery, GetMoviesQueryResult>(new GetMoviesQuery(pageIndex));

            var result = new MoviesViewModel { Movies = moviesResult.Movies, MoviesCount = moviesCount };

            return View(result);
        }
        public async Task<IActionResult> Details(int movieId)
        {
            var moviesResult = await _queryHandlerFactory.ResolveAndExecuteAsync<GetMovieDetailsQuery, GetMovieDetailsQueryResult>(new GetMovieDetailsQuery(movieId));


            return View(moviesResult.MovieDetailsViewModel);
        }
    }
}