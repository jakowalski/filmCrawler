using System.Linq;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.DataAccessLayer;

namespace FilmCrawler.WebClient.Features.GetMoviesCountQuery
{
    public class GetMoviesCountQueryAsyncHandler: BaseQueryAsyncHandler<GetMoviesCountQuery, long>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetMoviesCountQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task<long> RunQueryAsync(GetMoviesCountQuery query)
        {
            var moviesCount = _dbContext.ImdbMovie.LongCount();
            
            return Task.FromResult(moviesCount);
        }
    }
}
