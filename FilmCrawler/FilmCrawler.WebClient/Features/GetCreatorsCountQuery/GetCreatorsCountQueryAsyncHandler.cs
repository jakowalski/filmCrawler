using System.Linq;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.DataAccessLayer;

namespace FilmCrawler.WebClient.Features.GetCreatorsCountQuery
{
    public class GetCreatorsCountQueryAsyncHandler : BaseQueryAsyncHandler<GetCreatorsCountQuery, long>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetCreatorsCountQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task<long> RunQueryAsync(GetCreatorsCountQuery query)
        {
            var creatorsCount = _dbContext.Creator.LongCount();

            return Task.FromResult(creatorsCount);
        }
    }
}
