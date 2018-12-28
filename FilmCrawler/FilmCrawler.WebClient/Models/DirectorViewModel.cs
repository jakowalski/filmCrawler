using FilmCrawler.Core.Models.Dto;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Models
{
    public class DirectorViewModel
    {
        public long Count { get; set; }
        public IEnumerable<DirectorDto> Directors { get; set; }
    }
}
