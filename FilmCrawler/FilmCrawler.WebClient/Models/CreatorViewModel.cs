using FilmCrawler.Core.Models.Dto;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Models
{
    public class CreatorViewModel
    {
        public long Count { get; set; }

        public IEnumerable<CreatorDto> Creators { get; set; }
    }
}
