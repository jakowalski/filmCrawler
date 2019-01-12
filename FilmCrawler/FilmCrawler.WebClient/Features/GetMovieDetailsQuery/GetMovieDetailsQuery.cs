using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.WebClient.Features.GetMovieDetailsQuery
{
    public class GetMovieDetailsQuery : IQuery
    {
        public int MovieId { get; set; }

        public GetMovieDetailsQuery(int movieId)
        {
            MovieId = movieId; 
        }
    }
}
