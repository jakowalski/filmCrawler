

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class ActorImdbMovie
    {
        public int ImdbMovieId { get; set; }
        public ImdbMovie ImdbMovie { get; set; }       
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
