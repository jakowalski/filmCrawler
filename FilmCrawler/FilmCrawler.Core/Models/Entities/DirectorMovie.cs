

namespace FilmCrawler.Core.Models.Entities
{
    public class DirectorMovie
    {
        public int ImdbMovieId { get; set; }
        public ImdbMovie ImdbMovie { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
