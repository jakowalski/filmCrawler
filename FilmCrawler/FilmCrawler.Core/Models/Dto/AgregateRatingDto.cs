namespace FilmCrawler.Core.Models.Dto
{
    public class AggregateRating
    {
        public int RatingCount { get; set; }
        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }
        public AggregateRating()
        {

        }
        public AggregateRating(int ratingCount, string worstRating, string bestRating, string ratingValue)
        {
            RatingCount = ratingCount;
            WorstRating = worstRating;
            BestRating = bestRating;
            RatingValue = ratingValue;
        }
    }
}
