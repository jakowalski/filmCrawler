
namespace FilmCrawler.Core.Models.Entities
{
    public class CreatorImdbMovie
    {
        public int ImdbMovieId { get; set; }
        public ImdbMovie ImdbMovie { get; set; }
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
    }
}
