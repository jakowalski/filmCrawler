

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class AggregateRating:BaseEntity
    {
        public int RatingCount { get; set; }

        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }
    }
}
