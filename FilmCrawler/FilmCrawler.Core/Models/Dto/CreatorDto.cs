

namespace FilmCrawler.Core.Models.Dto
{
    public class CreatorDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public CreatorDto(int id, string url)
        {
            Id = id;
            Url = url;
        }
        public static CreatorDto Create(int id, string url)
        {
            return new CreatorDto(id, url);
        }
    }
}
