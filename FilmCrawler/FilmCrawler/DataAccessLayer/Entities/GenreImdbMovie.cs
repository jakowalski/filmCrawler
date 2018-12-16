

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class GenreImdbMovie
    {
        public int ImdbMovieId { get; set; }
        public ImdbMovie ImdbMovie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
