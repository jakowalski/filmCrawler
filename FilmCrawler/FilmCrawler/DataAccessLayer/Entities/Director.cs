

using System.Collections.Generic;

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class Director:BaseEntity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public ICollection<DirectorMovie> DirectorMovies { get; set; }

        public Director()
        {

        }
        public Director(string url, string name)
        {
            Url = url;
            Name = name;
        }
    }
}
