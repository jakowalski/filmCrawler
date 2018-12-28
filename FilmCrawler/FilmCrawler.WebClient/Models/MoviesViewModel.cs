using FilmCrawler.Core.Modles;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Models
{
    public class MoviesViewModel
    {
        public IEnumerable<ImdbMovieDto> Movies { get; set; }

        public long MoviesCount { get; set; }
    }
}
