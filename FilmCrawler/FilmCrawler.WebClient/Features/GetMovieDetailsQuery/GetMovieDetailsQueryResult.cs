using FilmCrawler.WebClient.Models;

namespace FilmCrawler.WebClient.Features.GetMovieDetailsQuery
{
    public class GetMovieDetailsQueryResult
    {
        public MovieDetailsViewModel MovieDetailsViewModel { get; set; }
        public GetMovieDetailsQueryResult(MovieDetailsViewModel movieDetailsViewModel)
        {
            MovieDetailsViewModel = movieDetailsViewModel;
        }
        public GetMovieDetailsQueryResult()
        {

        }
    }
}
