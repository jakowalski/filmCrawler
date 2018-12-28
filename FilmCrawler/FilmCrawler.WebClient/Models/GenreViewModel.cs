using FilmCrawler.Core.Models.Dto;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Models
{
    public class GenreViewModel
    {
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
