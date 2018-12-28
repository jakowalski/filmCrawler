using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Modles;
using FilmCrawler.DataAccessLayer;

namespace FilmCrawler.WebClient.Features.GetMoviesQuery
{
    public class GetMoviesQueryAsyncHandler: BaseQueryAsyncHandler<GetMoviesQuery, GetMoviesQueryResult>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetMoviesQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task<GetMoviesQueryResult> RunQueryAsync(GetMoviesQuery query)
        {
            var moviesRaw = _dbContext.ImdbMovie.Skip(query.PageIndex * 1000).Take(1000);

            var moviesResult = new List<ImdbMovieDto>();

            foreach (var movie in moviesRaw)
            {
                moviesResult.Add(ImdbMovieDto.Create(movie.Id,movie.Title,movie.Url,movie.Keywords,movie.DatePublished,movie.Description));
            }
            return Task.FromResult(new GetMoviesQueryResult(moviesResult));
        }
    }
}
