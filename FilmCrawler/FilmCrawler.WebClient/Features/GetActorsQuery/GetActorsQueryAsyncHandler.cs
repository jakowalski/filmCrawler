using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Features.GetActorsQuery
{
    public class GetActorsQueryAsyncHandler : BaseQueryAsyncHandler<GetActorsQuery, List<ActorDto>>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetActorsQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task<List<ActorDto>> RunQueryAsync(GetActorsQuery query)
        {
            var actorsRaw = _dbContext.Actor.Skip(query.PageIndex * 1000).Take(1000);

            var actorsResult = new List<ActorDto>();

            foreach (var actor in actorsRaw)
            {
                actorsResult.Add(ActorDto.Create(actor.Id, actor.Url, actor.Name));
            }
            return Task.FromResult(actorsResult);
        }
    }
}
