
namespace FilmCrawler.Core.Models.Dto
{
    public class ReviewDto
    {
        public ItemReviewedDto ItemReviewed { get; set; }
        public PersonDto Author { get; set; }
        public string DateCreated { get; set; }
        public string InLanguage { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public ReviewRatingDto ReviewRating { get; set; }

    }
}
