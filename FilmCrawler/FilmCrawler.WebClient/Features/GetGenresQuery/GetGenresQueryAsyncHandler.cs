using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCrawler.WebClient.Features.GetGenresQuery
{
    public class GetGenresQueryAsyncHandler : BaseQueryAsyncHandler<GetGenresQuery, List<GenreDto>>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetGenresQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task<List<GenreDto>> RunQueryAsync(GetGenresQuery query)
        {
            var genresRaw = _dbContext.Genre;

            var genresResult = new List<GenreDto>();

            foreach (var genre in genresRaw)
            {
                genresResult.Add(GenreDto.Create(genre.Id, genre.Name));
            }

            return Task.FromResult(genresResult);
        }
    }
}
