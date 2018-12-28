using FilmCrawler.Core.Modles;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Features.GetMoviesQuery
{
    public class GetMoviesQueryResult
    {
        public IEnumerable<ImdbMovieDto> Movies { get; set; }

        public GetMoviesQueryResult(IEnumerable<ImdbMovieDto> movies)
        {
            Movies = movies;
        }
    }
}
