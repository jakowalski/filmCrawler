

using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCrawler.Core.Models.Entities
{
    public class ReviewRating:BaseEntity
    {
        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public ReviewRating()
        {

        }
        public ReviewRating(string worstRating, string bestRating, string ratingValue)
        {
            WorstRating = worstRating;
            BestRating = bestRating;
            RatingValue = ratingValue;
        }
    }
}
