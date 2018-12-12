using System.Collections.Generic;


namespace FilmCrawler.DataAccessLayer.Entities
{
    public class ImdbMovie:BaseEntity
    {
        public string SiteId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Genre { get; set; }
        public string Duration { get; set; }
      
        public string Description { get; set; }
        public string DatePublished { get; set; }
        public string Keywords { get; set; }

        public  ICollection<Actor> Actors { get; set; }
        public  ICollection<Director> Directors { get; set; }

        public  ICollection<Creator> Creators { get; set; }

        public  AggregateRating AggregateRating { get; set; }
        public  Review Review { get; set; }

    }
}




