using System.Collections.Generic;

namespace FilmCrawler.Core.Models.Entities
{
    public class Creator:BaseEntity
    {
        public string Url { get; set; }

        public ICollection<CreatorImdbMovie> CreatorMovies { get; set; }
        public Creator()
        {

        }
        public Creator(string url)
        {
            Url = url;
        }

    }
}
