

using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCrawler.Core.Models.Entities
{
    public class Review:BaseEntity
    {
        public ItemReviewed ItemReviewed { get; set; }
        public Person Author { get; set; }
        public string DateCreated { get; set; }
        public string InLanguage { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }

        [ForeignKey("ImdbMovie")]
        public int ImdbMovieId { get; set; }
        public virtual ImdbMovie ImdbMovie { get; set; }

        public ReviewRating ReviewRating { get; set; }
        public Review()
        {

        }
        public Review(string name,
                      string reviewBody,
                      string inLanguage,
                      string dateCreated,
                      ItemReviewed itemReviewed,
                      Person author,
                      ReviewRating reviewRating)
        {
            Name = name;
            ReviewBody = reviewBody;
            InLanguage = inLanguage;
            DateCreated = dateCreated;
            ItemReviewed = itemReviewed;
            Author = author;
            ReviewRating = reviewRating;


        }
    }
}
