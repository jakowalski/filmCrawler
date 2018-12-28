using System.Collections.Generic;

namespace FilmCrawler.Core.Models.Entities
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<GenreImdbMovie> GenreImdbMovies { get; set; }

        public Genre()
        {

        }
        public Genre(string name)
        {
            Name = name;
        }
    }
}
