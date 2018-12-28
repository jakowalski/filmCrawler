using FilmCrawler.Core.Models.Dto;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Models
{
    public class ActorViewModel
    {
        public long Count { get; set; }
        public IEnumerable<ActorDto> Actors { get; set; }
    }
}
