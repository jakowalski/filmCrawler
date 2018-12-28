using System.Linq;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.DataAccessLayer;

namespace FilmCrawler.WebClient.Features.GetActorsCountQuery
{
    public class GetActorsCountQueryAsyncHandler : BaseQueryAsyncHandler<GetActorsCountQuery, long>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetActorsCountQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task<long> RunQueryAsync(GetActorsCountQuery query)
        {
            var actorsCount = _dbContext.Actor.LongCount();

            return Task.FromResult(actorsCount);
        }
    }
}
