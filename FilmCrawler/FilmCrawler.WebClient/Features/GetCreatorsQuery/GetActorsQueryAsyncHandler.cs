using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Features.GetCreatorsQuery
{
    public class GetCreatorsQueryAsyncHandler : BaseQueryAsyncHandler<GetCreatorsQuery, List<CreatorDto>>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetCreatorsQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task<List<CreatorDto>> RunQueryAsync(GetCreatorsQuery query)
        {
            var creatorsRaw = _dbContext.Creator.Skip(query.PageIndex * 1000).Take(1000);

            var creatorsResult = new List<CreatorDto>();

            foreach (var creator in creatorsRaw)
            {
                creatorsResult.Add(CreatorDto.Create(creator.Id, creator.Url));
            }
            return Task.FromResult(creatorsResult);
        }
    }
}
