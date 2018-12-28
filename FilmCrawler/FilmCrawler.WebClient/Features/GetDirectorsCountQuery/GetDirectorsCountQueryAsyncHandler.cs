using System.Linq;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.DataAccessLayer;

namespace FilmCrawler.WebClient.Features.GetDirectorsCountQuery
{
    public class GetDirectorsCountQueryAsyncHandler : BaseQueryAsyncHandler<GetDirectorsCountQuery, long>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetDirectorsCountQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task<long> RunQueryAsync(GetDirectorsCountQuery query)
        {
            var directorsCount = _dbContext.Director.LongCount();

            return Task.FromResult(directorsCount);
        }
    }
}
