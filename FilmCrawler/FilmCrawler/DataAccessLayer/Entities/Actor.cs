
using System.Collections.Generic;

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class Actor:BaseEntity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public  ICollection<ActorImdbMovie> ActorMovies { get; set; }
        public Actor()
        {

        }
        public Actor(string url,string name)
        {
            Url = url;
            Name = name;
        }

    }
}
