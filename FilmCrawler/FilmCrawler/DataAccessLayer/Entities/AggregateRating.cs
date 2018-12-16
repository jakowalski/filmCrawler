

using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class AggregateRating:BaseEntity
    {
        public int RatingCount { get; set; }

        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }

        [ForeignKey("ImdbMovie")]
        public int ImdbMovieId { get; set; }
        public virtual ImdbMovie ImdbMovie { get; set; }
        public AggregateRating()
        {

        }
        public AggregateRating(int ratingCount,string worstRating,string bestRating,string ratingValue)
        {
            RatingCount = ratingCount;
            WorstRating = worstRating;
            BestRating = bestRating;
            RatingValue = ratingValue;
        }
    }
}
