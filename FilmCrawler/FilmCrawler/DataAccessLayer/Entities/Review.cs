

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class Review:BaseEntity
    {
        public ItemReviewed ItemReviewed { get; set; }
        public Person Author { get; set; }
        public string DateCreated { get; set; }
        public string InLanguage { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public ReviewRating ReviewRating { get; set; }
    }
}
