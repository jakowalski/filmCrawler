using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Features.GetDirectorsQuery
{
    public class GetDirectorsQueryAsyncHandler : BaseQueryAsyncHandler<GetDirectorsQuery, List<DirectorDto>>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetDirectorsQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task<List<DirectorDto>> RunQueryAsync(GetDirectorsQuery query)
        {
            var directorsRaw = _dbContext.Director.Skip(query.PageIndex * 1000).Take(1000);

            var directorsResult = new List<DirectorDto>();

            foreach (var director in directorsRaw)
            {
                directorsResult.Add(DirectorDto.Create(director.Id, director.Name, director.Url));
            }
            return Task.FromResult(directorsResult);
        }
    }
}
